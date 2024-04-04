using Entity.Ability.Enemy;

namespace CombatSystem
{
    public class CrocController : WanderingEntityController
    {
        protected override void Start()
        {
            base.Start();
            executor.Init(gameObject.AddComponent<HuntingAbility>(), this, targetLayer);
        }

        public override string GetName()
        {
            return "Crocdile";
        }
    }
}