using CombatSystem;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

namespace UIScripts
{
    public class HealthUIController : MonoBehaviour
    {
        [SerializeField] public LivingEntityController target;
        [SerializeField] public Sprite hpMask, missingMask, deadMask;

        private NavMeshAgent agent;
        private Image maskImage;

        private void Start()
        {
            maskImage = GetComponent<Image>();
            Invoke(nameof(GetAgentLater), 0.01f);
        }

        private void Update()
        {
            if (target.IsDead())
            {
                maskImage.sprite = deadMask;
                maskImage.fillAmount = 1;
            }
            else if (target.lost)
            {
                maskImage.sprite = missingMask;
                maskImage.fillAmount = 1;
            }
            else
            {
                maskImage.sprite = hpMask;
                maskImage.fillAmount = 1 - target.GetHealthPercentage();
            }
        }

        private void GetAgentLater()
        {
            agent = target.agent;
        }
    }
}