using System.Collections.Generic;
using Entity.Ability;
using UnityEngine;
using UnityEngine.UI;

namespace CombatSystem.Ability
{
    public class PlayerAbilityExecutor : MonoBehaviour
    {
        public Image maskImage1, maskImage2, maskImage3;

        [SerializeField] public GameObject projectilePrefab;

        private PlayerAbility ability1, ability2;
        private PlayerHonkAbility ability3;

        private Animator anim;
        private LivingEntityController controller;
        private DuckController duckController;

        private Dictionary<PlayerAbility, Image> masks;

        private void Start()
        {
            ability1 = gameObject.AddComponent<PlayerPeckAbility>();
            ability2 = gameObject.AddComponent<PlayerDashAbility>();
            ability3 = gameObject.AddComponent<PlayerHonkAbility>();
            ability3.SetProjectile(projectilePrefab);

            masks = new Dictionary<PlayerAbility, Image>();
            anim = GetComponent<Animator>();
            duckController = GetComponent<DuckController>();
            controller = GetComponent<LivingEntityController>();

            if (ability1 != null && maskImage1 != null) masks.Add(ability1, maskImage1);
            if (ability2 != null && maskImage2 != null) masks.Add(ability2, maskImage2);
            if (ability3 != null && maskImage3 != null) masks.Add(ability3, maskImage3);
        }

        private void Update()
        {
            if (masks == null) return;
            if (duckController != null && duckController.stunned) return;
            
            foreach (var ability in masks.Keys)
            {
                masks[ability].fillAmount = ability.CooldownPercentage();

                if (!Input.GetKeyDown(ability.GetKey())) continue;
                if (!ability.CanUse())
                {
                    duckController.ShowText("On Cooldown!", 0.25f);
                    continue;
                }

                RaycastHit hit;
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity))
                    if (hit.collider.CompareTag("Terrain") || hit.collider.CompareTag("Enemy"))
                        duckController.Rotation(hit.point);

                var executed = ability.UseAbility(controller);
                if (executed)
                {
                    anim.SetTrigger(ability.GetAnimationTrigger());
                    ability.StartCooldown();
                }
                else
                {
                    duckController.ShowText("No target found!", 0.5f);
                }
            }
        }
    }
}