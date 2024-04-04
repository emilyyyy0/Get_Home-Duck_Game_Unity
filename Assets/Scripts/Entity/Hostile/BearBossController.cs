using System;
using CombatSystem;
using Entity.Ability.Enemy;
using UnityEngine;

public class BearBossController : WanderingEntityController
{
    [SerializeField] private ProgressBar UIHealthBar;
    [NonSerialized] private BossFightAndHouseHandler houseHandler;

    protected override void Start()
    {
        base.Start();
        executor.Init(gameObject.AddComponent<HuntingAbility>().SetDetectionRadius(30f), this, targetLayer);
        // executor.Init(gameObject.AddComponent<ChargeAbility>(), this, targetLayer);
        // executor.Init(gameObject.AddComponent<GroundSmashAbility>(), this, targetLayer);
    }

    protected override void Update()
    {
        base.Update();
        if (UIHealthBar != null)
        {
            UIHealthBar.BarValue = GetHealthPercentage();
            if (currentHealth <= 0) UIHealthBar.gameObject.SetActive(false);
        }
    }

    private void OnEnable()
    {
        Stun(5f);

        // Start the rising coroutine
        InvokeRepeating(nameof(RaiseEntity), 0.5f, 0.01f);
    }

    public void RegisterHouseHandler(BossFightAndHouseHandler houseHandler)
    {
        this.houseHandler = houseHandler;
    }

    private void RaiseEntity()
    {
        if (transform.position.y >= 11)
        {
            CancelInvoke();
            agent.enabled = true;
            UIHealthBar.gameObject.SetActive(true);
            return;
        }

        transform.position = new Vector3(transform.position.x, transform.position.y + 0.025f, transform.position.z);
    }

    public override float GetDefaultSpeed()
    {
        return 2f;
    }

    public override string GetName()
    {
        return "Bear";
    }

    public override void Die()
    {
        base.Die();
        UIHealthBar.gameObject.SetActive(false);
        houseHandler.GiveKey();
    }

    public override float GetAttackRange()
    {
        return 10f;
    }
    
    public bool Attack()
    {
        var timeSinceLastAttack = Time.time - lastAttackTime;
        if (timeSinceLastAttack >= attackSpeedPerSecond && target != null)
        {
            var character = target.GetComponent<LivingEntityController>();
            if (character != null)
            {
                var killed = character.TakeDamage(attackDamage);
                
                // TODO: Bugged
                Debug.Log("Sending up " + character.GetName());
                character.GetVelocityManager().ApplyVelocity(
                    Vector3.up * 100f,
                    ForceMode.Impulse,
                    2f);
                lastAttackTime = Time.time;
                return killed;
            }
        }
            
        return false;
    }
}