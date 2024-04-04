using Entity.Ability;
using UnityEngine;

namespace CombatSystem.Ability
{
    public class PlayerHonkAbility : PlayerAbility
    {
        public float stunDuration = 2f;
        private GameObject projectilePrefab;

        public void SetProjectile(GameObject prefab)
        {
            projectilePrefab = prefab;
        }

        public override bool UseAbility(LivingEntityController duck)
        {
            ShootProjectile();
            return true;
        }

        private void ShootProjectile()
        {
            var projectile = Instantiate(projectilePrefab, transform.position + Vector3.up, transform.rotation);
            projectile.GetComponent<ProjectileHandler>().OnCollisionEnterEvent +=
                HandleProjectileCollision;
        }

        private void HandleProjectileCollision(Collider other)
        {
            // Check if the collision is with an enemy
            if (other.CompareTag("Enemy"))
            {
                // Get the enemy's script (you'll need to replace "EnemyScript" with your actual enemy script)
                var enemy = other.GetComponent<LivingEntityController>();

                if (enemy != null)
                {
                    enemy.TakeDamage(30f);
                    // Apply the stun effect to the enemy
                    enemy.Stun(stunDuration);
                }
            }
        }

        public override KeyCode GetKey()
        {
            return KeyCode.W;
        }

        public override float GetCooldownSeconds()
        {
            return 3f;
        }

        public override string GetAnimationTrigger()
        {
            return "HonkAbility";
        }
    }
}