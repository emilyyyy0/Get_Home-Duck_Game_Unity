using UnityEngine;

namespace CombatSystem
{
    public class FishController : WanderingEntityController
    {
        protected override void Start()
        {
            base.Start();
            agent.baseOffset = Random.Range(-1f, -0.2f);
        }

        public override Color GetHPAndOutlineColor()
        {
            return Color.green;
        }

        public override string GetName()
        {
            return "Fish";
        }

        public override string GetNameTagText()
        {
            return GetName();
        }
    }
}