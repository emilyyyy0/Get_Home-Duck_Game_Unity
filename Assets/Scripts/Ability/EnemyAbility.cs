using System;
using CombatSystem;
using CombatSystem.Ability;
using UnityEngine;
using UnityEngine.AI;

namespace Entity
{
    [Serializable]
    public abstract class EnemyAbility : AbstractAbility
    {
        protected NavMeshAgent agent;
        protected WanderingEntityController currentEntity;
        public EventHandler OnFinish;

        public virtual void Reset()
        {
        }

        public void RegisterController(WanderingEntityController entity)
        {
            currentEntity = entity;
            agent = entity.agent;
        }

        public virtual void StartAbility()
        {
        }

        public virtual void RunAbility()
        {
        }

        public override float GetCooldownSeconds()
        {
            return 0;
        }

        public virtual void FinishAbility()
        {
            OnFinish?.Invoke(this, null);
        }

        public virtual int GetDuration()
        {
            return -1;
        }

        public override string GetEmemyTag()
        {
            return "Duckling";
        }

        public abstract int GetChance();

        protected virtual LivingEntityController FindTarget(float detectionRadius)
        {
            // Check for targets within detection radius
            var colliders = new Collider[6];
            var numColliders = Physics.OverlapSphereNonAlloc(currentEntity.transform.position, detectionRadius,
                colliders, currentEntity.targetLayer);
            LivingEntityController tempController = null;
            
            if (numColliders == 0) return null;

            // Iterate through the colliders found.
            for (var i = 0; i < numColliders; i++)
            {
                var controller = colliders[i]
                    .gameObject
                    .GetComponent<LivingEntityController>();

                if (controller != null)
                {
                    if (controller.CompareTag(GetEmemyTag())) return controller;
                    tempController = controller;
                };
            }

            return tempController;
        }
    }
}