using Entity.Ability;
using UnityEngine;

namespace CombatSystem.Ability
{
    public class PlayerDashAbility : PlayerAbility
    {
        public override bool UseAbility(LivingEntityController duck)
        {
            // Get the mouse cursor position in screen space
            var mouseScreenPos = Input.mousePosition;

            // Convert the screen space position to a ray in world space
            var ray = Camera.main.ScreenPointToRay(mouseScreenPos);

            // Perform a raycast to determine the target position
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                var dashDirection = hit.point - duck.transform.position;
                dashDirection.y = 0;
                duck.GetVelocityManager().ApplyVelocity(
                    dashDirection.normalized * 15f,
                    ForceMode.VelocityChange,
                    0.5f);
            }

            return true;
        }

        public override KeyCode GetKey()
        {
            return KeyCode.E;
        }

        public override float GetCooldownSeconds()
        {
            return 2f;
        }

        public override string GetAnimationTrigger()
        {
            return "DashAbility";
        }
    }
}