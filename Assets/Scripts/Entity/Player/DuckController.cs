using System.Collections;
using CombatSystem;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DuckController : LivingEntityController
{
    [SerializeField] public TextMeshProUGUI textMeshPro;
    [SerializeField] public TextMeshProUGUI targetText;

    // Audio 
    public AudioClip normalMusic;
    public AudioClip bossMusic;
    public AudioClip victoryMusic;
    
    private AudioSource audioSource;
    private BossFightAndHouseHandler bossFightAndHouseHandler;
    private bool canAttack = true;
    private float nextAttackTime;
    private float rotateVelocity;

    protected override void Start()
    {
        base.Start();
        // HighlightManager = gameObject.GetComponent<HighlightManager>();

        bossFightAndHouseHandler = gameObject.GetComponent<BossFightAndHouseHandler>();
        bossFightAndHouseHandler.RegisterController(this);

        //Initialise the AudioSource Component and set normal music as the default clip 
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = normalMusic;
        audioSource.loop = true;
        audioSource.Play();


        if (textMeshPro is not null) textMeshPro.gameObject.SetActive(false);
    }

    public override float GetAttackRange()
    {
        float multi = 1;
        if (bossFightAndHouseHandler != null && bossFightAndHouseHandler.fightOn)
        {
            multi = 3;
        }
        return 4f * multi;
    }

    protected override void Update()
    {
        base.Update();

        if (targetText != null)
        {
            targetText.text = "Targetting : " + (target == null ? "None" : target.GetName());
        }

        ClickHandler();
        TargetHandler();
    }

    public override float GetDefaultSpeed()
    {
        return 4f;
    }

    private IEnumerator MeleeAttackInterval()
    {
        canAttack = false;

        animator.SetBool("isAttacking", true);

        yield return new WaitForSeconds(attackSpeedPerSecond);

        if (target == null)
        {
            animator.SetBool("isAttacking", false);
            canAttack = true;
        }
    }

    private void ClickHandler()
    {
        // HighlightManager.HoverHighlight();
        if (Input.GetMouseButtonDown((int)MouseButton.Right) && !IsDead())
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity))
            {
                if (hit.collider == null) return;

                if (hit.collider.CompareTag("Terrain") ||
                    hit.collider.CompareTag("Water") ||
                    hit.collider.CompareTag("BossArea") ||
                    hit.collider.CompareTag("AudioMarker") ||
                    hit.collider.CompareTag("Mud") ||
                    hit.collider.CompareTag("House"))
                {
                    MoveToPos(hit.point);
                }

                else if (hit.collider.CompareTag("Enemy"))
                    MoveToEnemy(hit.collider.GetComponent<LivingEntityController>());
            }
        }
    }

    private void TargetHandler()
    {
        if (target is not null && !target.IsDestroyed())
            if (Vector3.Distance(transform.position, target.transform.position) > GetAttackRange())
            {
                agent.SetDestination(target.transform.position);
            }
            else
            {
                if (canAttack && Time.time > nextAttackTime)
                {
                    StartCoroutine(MeleeAttackInterval());
                }
            }
    }

    private void MoveToPos(Vector3 pos)
    {
        agent.SetDestination(pos);
        agent.stoppingDistance = 0;

        Rotation(pos);
        
        target = null;
    }

    private void MoveToEnemy(LivingEntityController enemy)
    {
        if (enemy == null || stunned) return;
        target = enemy;
        agent.SetDestination(target.transform.position);
        agent.stoppingDistance = GetAttackRange();
        Rotation(target.transform.position);
        ShowText("Now Targeting " + target.GetName(), 0.5f);
    }

    private void MeleeAttack()
    {
        if (target == null) return;
        transform.LookAt(target.transform);
        target.TakeDamage(attackDamage);
        nextAttackTime = Time.time + attackSpeedPerSecond;
        canAttack = true;
        animator.SetBool("isAttacking", false);
    }

    public void Rotation(Vector3 lookAtPos)
    {
        StopRotationUpdate();
        var rotationToLookAt = Quaternion.LookRotation(lookAtPos - transform.position);
        var rotationY = Mathf.SmoothDampAngle(transform.eulerAngles.y,
            rotationToLookAt.eulerAngles.y,
            ref rotateVelocity,
            0);

        transform.eulerAngles = new Vector3(0, rotationY, 0);
        StartRotationUpdate();
    }

    public override string GetName()
    {
        return "Duck";
    }

    public override void RemoveEntity()
    {
        base.RemoveEntity();
        SceneManager.LoadScene(2);
    }

    public override Color GetHPAndOutlineColor()
    {
        return Color.yellow;
    }

    public void ShowText(string text, float seconds)
    {
        if (textMeshPro is null) return;
        textMeshPro.text = text;
        textMeshPro.gameObject.SetActive(true);
        StartCoroutine(HideText(seconds));
    }

    public IEnumerator HideText(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        textMeshPro.gameObject.SetActive(false);
    }


    public void SwitchMusic(AudioClip newClip)
    {
        if (audioSource.clip != newClip)
        {
            audioSource.clip = newClip;
            audioSource.Play();
        }
    }
}