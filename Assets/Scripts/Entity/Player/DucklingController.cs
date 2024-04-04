using CombatSystem;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DucklingController : LivingEntityController
{
    private static int _ducklingCount = 5;
    [Range(1, 6)] public int distanceBehind;

    protected override void Start()
    {
        base.Start();
        target = FindObjectOfType<DuckController>();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        if (target == null) return;

        SetDestination(GetBehindPosition(target.transform));
        if (Utils.SquaredDistance(transform.position,
                target.transform.position) > 15f * 15f)
        {
            lost = true; // Used for HealthUIController
            StopAgent();
        }
        else
        {
            lost = false;
            StartAgent();
        }
    }

    public override float GetDefaultSpeed()
    {
        return 3.5f;
    }

    private Vector3 GetBehindPosition(Transform entity)
    {
        if (entity == null) return transform.position;
        return entity.position - entity.forward * distanceBehind;
    }

    public override string GetName()
    {
        return "";
    }
}