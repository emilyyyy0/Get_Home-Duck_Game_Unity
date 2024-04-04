using System;
using System.Collections;
using Entity.Ability;
using Movement;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Assertions;

namespace CombatSystem
{
    public abstract class LivingEntityController : MonoBehaviour
    {
        public delegate void OnDeathDelegate();

        public float attackRange = 4f, attackSpeedPerSecond = 1f, attackDamage = 10;
        public float maxHealth = 100, defaultSpeed = 3f;

        //For blood on death
        public GameObject Blood;

        private readonly float motionSmoothTime = .1f;
        [NonSerialized] public NavMeshAgent agent;
        [NonSerialized] public Animator animator;
        [NonSerialized] public float currentHealth;
        protected EnemyAbilityExecutor executor;

        [NonSerialized] public ProgressBar healthBar;

        private bool isSpeedBoostActive;
        public float lastAttackTime;
        [NonSerialized] public bool lost;
        [NonSerialized] public LivingEntityController player;
        private float remainingSpeedTime;
        public bool stunned, dead, removed;
        [NonSerialized] public LivingEntityController target;
        private NavMeshVelocityManager velocityManager;

        protected virtual void Start()
        {
            velocityManager = gameObject.AddComponent<NavMeshVelocityManager>();
            velocityManager.RegisterController(this);

            player = FindObjectOfType<DuckController>();

            agent = GetComponent<NavMeshAgent>();
            agent.speed = GetDefaultSpeed();
            agent.angularSpeed = 1200;
            agent.acceleration = 50;
            agent.stoppingDistance = GetAttackRange();

            animator = GetComponent<Animator>();
            if (animator == null) Debug.LogWarning("Animator not found on " + name + ".");

            healthBar = GetComponentInChildren<ProgressBar>();
            if (healthBar != null) healthBar.BarColor = GetHPAndOutlineColor();
            currentHealth = maxHealth;

            executor = gameObject.AddComponent<EnemyAbilityExecutor>();
        }

        protected virtual void Update()
        {
            if (healthBar != null)
            {
                healthBar.BarValue = GetHealthPercentage();
                if (currentHealth <= 0) healthBar.gameObject.SetActive(false);
                healthBar.SetNameTagText(GetNameTagText());
            }

            if (currentHealth <= 0) Die();

            var speed = stunned ? 0 : agent.velocity.magnitude;
            animator.SetFloat("Speed", speed, motionSmoothTime, Time.deltaTime);

            if (isSpeedBoostActive)
            {
                remainingSpeedTime -= Time.deltaTime;
                if (remainingSpeedTime <= 0f) EndSpeedBoost();
            }
        }

        public event OnDeathDelegate OnDeath;

        public virtual float GetAttackRange()
        {
            return attackRange;
        }

        public virtual float GetDefaultSpeed()
        {
            return defaultSpeed;
        }

        // Returns true if attack killed entity.
        public bool TakeDamage(float damage)
        {
            currentHealth -= damage;
            return currentHealth <= 0;
        }

        public virtual void RemoveEntity()
        {
            if (removed) return;
            removed = true;

            OnDeath?.Invoke();
            Destroy(gameObject);

            if (Blood is not null) Instantiate(Blood, transform.position, Quaternion.identity);
        }

        public virtual void Die()
        {
            // HACKY: Die() is being called 246 times, workaround
            if (dead) return;
            dead = true;

            animator.SetBool("isDead", true);
            executor.Reset();
            StopAgent();
            Invoke(nameof(RemoveEntity), 2f);
        }

        public bool IsDead()
        {
            return currentHealth <= 0 || gameObject == null || gameObject.IsDestroyed();
        }

        public float GetHealthPercentage()
        {
            return currentHealth / maxHealth;
        }

        public NavMeshVelocityManager GetVelocityManager()
        {
            if (velocityManager is null) velocityManager = gameObject.AddComponent<NavMeshVelocityManager>();

            Assert.IsTrue(velocityManager is not null);
            return velocityManager;
        }

        public void ApplyFullHealth()
        {
            currentHealth = maxHealth;
        }

        public void StopAgent()
        {
            if (agent == null || !agent.isOnNavMesh) return;
            agent.isStopped = true;
            agent.updatePosition = false;
            agent.updateRotation = false;
        }

        public void StartAgent()
        {
            if (agent == null || !agent.isOnNavMesh) return;
            agent.isStopped = false;
            agent.updatePosition = true;
            agent.updateRotation = true;
        }

        public void StartRotationUpdate()
        {
            agent.updateRotation = true;
        }

        public void StopRotationUpdate()
        {
            agent.updateRotation = false;
        }

        public void Stun(float duration)
        {
            StopAgent();

            stunned = true;
            target = null;

            StartCoroutine(RecoverFromStun(duration));
        }

        private IEnumerator RecoverFromStun(float duration)
        {
            yield return new WaitForSeconds(duration);

            stunned = false;

            // Enable the enemy's movement or AI logic
            agent.Warp(agent.transform.position);
            StartAgent();
        }

        public void SetDestination(Vector3 dest)
        {
            if (agent is not null && agent.isOnNavMesh) agent.SetDestination(dest);
        }

        public void ApplySpeedBoost(float boost)
        {
            agent.speed += boost;
            remainingSpeedTime = boost;
            isSpeedBoostActive = true;
        }

        private void EndSpeedBoost()
        {
            agent.speed = GetDefaultSpeed();
            isSpeedBoostActive = false;
        }

        public abstract string GetName();

        public virtual Color GetHPAndOutlineColor()
        {
            return Color.green;
        }

        public virtual string GetNameTagText()
        {
            return GetName() + " " + (stunned ? "STUNNED" : currentHealth + "/" + maxHealth);
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
                    lastAttackTime = Time.time;
                    return killed;
                }
            }
            
            return false;
        }
    }
}