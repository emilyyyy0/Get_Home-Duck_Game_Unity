using Entity.Ability.Enemy;

namespace CombatSystem
{
    public class DeerController : WanderingEntityController
    {
        protected override void Start()
        {
            base.Start();
            executor.Init(gameObject.AddComponent<HuntingAbility>(), this, targetLayer);
        }

        public override string GetName()
        {
            return "Deer";
        }

        public override float GetDefaultSpeed()
        {
            return 2.5f;
        }

        public override float GetAttackRange()
        {
            return 5f;
        }
    }
}