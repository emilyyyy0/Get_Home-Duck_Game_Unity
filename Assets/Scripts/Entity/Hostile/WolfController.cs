using Entity.Ability.Enemy;

namespace CombatSystem
{
    public class WolfController : WanderingEntityController
    {
        protected override void Start()
        {
            base.Start();
            executor.Init(gameObject.AddComponent<HuntingAbility>(), this, targetLayer);
        }

        public override float GetDefaultSpeed()
        {
            return 3f;
        }

        /**
         * Agent Type -> Enemies
         * Add HealthBar
         * Add Wolf Controller
         * Add Blood
         * Select Ducks as Layer
         * Tag as Enemy
         * Fix Animations
         */
        public override string GetName()
        {
            return "Wolf";
        }
    }
}