using UnityEngine;

namespace Entity.Ability.Enemy
{
    public class HuntingAbility : EnemyAbility
    {
        private float detectionRadius = 10f;

        public override void Reset()
        {
            base.Reset();
            FinishAbility();
        }

        public override void StartAbility()
        {
            base.StartAbility();
            agent.speed *= 2;
        }

        public override void FinishAbility()
        {
            base.FinishAbility();
            agent.speed = currentEntity.GetDefaultSpeed();
            currentEntity.animator.SetBool("isAttacking", false);
            agent.SetDestination(agent.transform.position);
            currentEntity.target = null;
        }

        public override void RunAbility()
        {
            // Don't Hunt if Target is Null
            if (currentEntity.target == null || currentEntity.target.IsDead())
            {
                FinishAbility();
                return;
            }

            var distToTarget = Vector3.Distance(transform.position + transform.forward,
                currentEntity.target.transform.position);

            if (distToTarget <= currentEntity.GetAttackRange())
            {
                // Calculate the direction to the destination.
                var direction = (currentEntity.target.transform.position - transform.position).normalized;

                // Calculate the rotation that faces the destination.
                var targetRotation = Quaternion.LookRotation(direction);

                // Apply the rotation.
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 5f * Time.deltaTime);

                currentEntity.animator.SetBool("isAttacking", true);
            }
            else
            {
                currentEntity.animator.SetBool("isAttacking", false);
            }

            if (distToTarget > detectionRadius)
            {
                FinishAbility();
                return;
            }

            currentEntity.SetDestination(currentEntity.target.transform.position);
        }

        public HuntingAbility SetDetectionRadius(float newRadius)
        {
            detectionRadius = newRadius;
            return this;
        }

        public override bool CanUse()
        {
            currentEntity.target = FindTarget(detectionRadius);
            return currentEntity.target != null;
        }

        public override int GetDuration()
        {
            return 7;
        }

        public override int GetChance()
        {
            return 100;
        }
    }
}