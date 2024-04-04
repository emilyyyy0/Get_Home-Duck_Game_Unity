using CombatSystem;
using UnityEngine;

namespace Entity.Ability.Enemy
{
    public class GroundSmashAbility : EnemyAbility
    {
        public override int GetChance()
        {
            return 30;
        }

        public override float GetCooldownSeconds()
        {
            return 10;
        }

        public override void StartAbility()
        {
            currentEntity.StopAgent();

            currentEntity.animator.SetTrigger("GroundPound");

            Invoke(nameof(StartLater), 3);
        }

        private void StartLater()
        {
            currentEntity.StartAgent();
            FinishAbility();
        }

        public override string GetEmemyTag()
        {
            return "Player";
        }
    }
}