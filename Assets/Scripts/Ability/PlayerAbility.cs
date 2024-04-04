using CombatSystem;
using CombatSystem.Ability;
using UnityEngine;

namespace Entity.Ability
{
    public abstract class PlayerAbility : AbstractAbility
    {
        public abstract bool UseAbility(LivingEntityController duck);
        public abstract KeyCode GetKey();
        public abstract string GetAnimationTrigger();

        public override string GetEmemyTag()
        {
            return "Enemy";
        }
    }
}