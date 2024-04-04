using System;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

namespace Entity.Ability
{
    public class EnemyAbilityExecutor : MonoBehaviour
    {
        private readonly List<EnemyAbility> abilities = new();
        private readonly Random random = new();
        private EnemyAbility currentAbility;
        private LayerMask mask;

        public void Reset()
        {
            foreach (var ability in abilities) ability.Reset();
            currentAbility = null;
        }

        private void Start()
        {
            InvokeRepeating(nameof(UpdateAbility), 0, 1f);
        }

        public void Init(EnemyAbility ability, WanderingEntityController controller, LayerMask enemyMask)
        {
            ability.RegisterController(controller);
            abilities.Add(ability);
            mask = enemyMask;
        }

        public bool AbilityActive()
        {
            return currentAbility != null;
        }

        public EnemyAbility GetCurrentAbility()
        {
            return currentAbility;
        }

        private void FinishAbility(object sender, EventArgs args)
        {
            if (!AbilityActive()) return;
            currentAbility = null;
        }

        private void GetNewAbility()
        {
            if (abilities.Count == 0) return;

            var randomNumber = random.NextDouble() * 100; // Generates a number from 0 to 100 (inclusive)
            EnemyAbility rarestAbility = null;
            foreach (var ability in abilities)
            {
                if (!ability.CanUse()) continue;
                if (randomNumber > ability.GetChance()) continue;
                if (rarestAbility is null || rarestAbility.GetChance() > ability.GetChance()) rarestAbility = ability;
            }

            if (rarestAbility == null) return;

            currentAbility = rarestAbility;
            currentAbility.OnFinish += FinishAbility;
            currentAbility.StartAbility();

            if (currentAbility.GetDuration() != -1)
                currentAbility.Invoke(nameof(FinishAbility),
                    currentAbility.GetDuration());
        }

        private void UpdateAbility()
        {
            if (!AbilityActive()) GetNewAbility();
        }
    }
}