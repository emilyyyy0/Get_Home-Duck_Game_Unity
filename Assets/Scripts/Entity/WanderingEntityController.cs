using CombatSystem;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.AI;

public abstract class WanderingEntityController : LivingEntityController
{
    public float wanderRadius = 30f; // Radius for wandering
    public LayerMask targetLayer;
    private readonly int SQR_RETURN_DIST = 40 * 40;
    private Vector3 startLocation;
    private Vector3 wanderDestination; // Destination for wandering

    protected override void Start()
    {
        base.Start();
        startLocation = transform.position;
        agent.speed = GetDefaultSpeed();
        InvokeRepeating(nameof(FindWanderDestination), 0, 3);
    }

    protected override void Update()
    {
        // Pause Entities which are too far away
        if (Utils.SquaredDistance(transform.position, player.transform.position) > SQR_RETURN_DIST) return;

        base.Update();

        if (Utils.SquaredDistance(startLocation, transform.position) > SQR_RETURN_DIST)
        {
            agent.destination = startLocation;
            agent.Warp(startLocation);
            executor.Reset();
        }

        if (executor != null && executor.AbilityActive()) executor.GetCurrentAbility().RunAbility();
        else SetDestination(wanderDestination);
    }

    private void FindWanderDestination()
    {
        // Calculate a random point within the wander radius
        var randomDirection = Random.insideUnitSphere * wanderRadius;
        randomDirection += transform.position;
        NavMeshHit hit;
        NavMesh.SamplePosition(randomDirection, out hit, wanderRadius, 1);
        wanderDestination = hit.position;
    }

    public override Color GetHPAndOutlineColor()
    {
        return Color.red;
    }
}