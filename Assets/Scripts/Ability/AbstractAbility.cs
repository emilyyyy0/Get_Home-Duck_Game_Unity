using System;
using UnityEngine;

namespace CombatSystem.Ability
{
    public abstract class AbstractAbility : MonoBehaviour
    {
        public string abilityName;
        private float lastUsedTimeStamp = -1000f;

        public abstract float GetCooldownSeconds();
        public abstract string GetEmemyTag();

        public virtual bool CanUse()
        {
            return Time.time - lastUsedTimeStamp >= GetCooldownSeconds();
        }

        public void StartCooldown()
        {
            lastUsedTimeStamp = Time.time;
        }

        public float CooldownPercentage()
        {
            var secondsLeft = Math.Max(0, Time.time - lastUsedTimeStamp);
            return 1 - secondsLeft / GetCooldownSeconds();
        }
    }
}