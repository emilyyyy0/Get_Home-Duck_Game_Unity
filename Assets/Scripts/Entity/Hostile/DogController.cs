using Entity.Ability.Enemy;

namespace CombatSystem
{
    public class DogController : WanderingEntityController
    {
        protected override void Start()
        {
            base.Start();
            executor.Init(gameObject.AddComponent<HuntingAbility>(), this, targetLayer);
        }

        public override string GetName()
        {
            return "Dog";
        }

        public override float GetDefaultSpeed()
        {
            return 4f;
        }

        public override float GetAttackRange()
        {
            return 2f;
        }
    }
}