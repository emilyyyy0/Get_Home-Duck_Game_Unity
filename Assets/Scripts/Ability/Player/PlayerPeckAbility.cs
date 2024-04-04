using Entity.Ability;
using UnityEngine;

namespace CombatSystem.Ability
{
    public class PlayerPeckAbility : PlayerAbility
    {
        private readonly float angle = 60f;
        private BossFightAndHouseHandler bossFightAndHouseHandler;

        private void Start()
        {
            bossFightAndHouseHandler = FindObjectOfType<BossFightAndHouseHandler>();
        }

        public float GetRadius()
        {
            return bossFightAndHouseHandler != null && bossFightAndHouseHandler.fightOn ? 15f : 5f;
        }

        public override bool UseAbility(LivingEntityController duck)
        {
            var transform = duck.transform;
            var forward = transform.forward;
            var hitColliders = Physics.OverlapSphere(transform.position, GetRadius());
            var attacked = false;

            foreach (var collider in hitColliders)
            {
                if (!collider.CompareTag(GetEmemyTag())) continue;

                var directionToEnemy = collider.transform.position - transform.position;
                var angleToEnemy = Vector3.Angle(forward, directionToEnemy);

                if (angleToEnemy <= angle * 0.5f)
                {
                    var entityController = collider.GetComponent<LivingEntityController>();
                    if (entityController != null)
                    {
                        attacked = true;
                        entityController.TakeDamage(15);

                        directionToEnemy.y = 1;
                        if (entityController.GetName() != "Bear")
                        {
                            entityController.GetVelocityManager().ApplyVelocity(
                                directionToEnemy.normalized * 8f,
                                ForceMode.Impulse,
                                0.5f);
                        }
                    }
                }
            }

            return attacked;
        }

        public override KeyCode GetKey()
        {
            return KeyCode.Q;
        }

        public override float GetCooldownSeconds()
        {
            return 1f;
        }

        public override string GetAnimationTrigger()
        {
            return "PeckAbility";
        }
    }
}