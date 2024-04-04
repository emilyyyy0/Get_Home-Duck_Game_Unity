using System.Collections;
using CombatSystem;
using UnityEngine;
using UnityEngine.AI;

namespace Movement
{
    /**
     * Adapted from https://stackoverflow.com/questions/66007738/unity-how-to-jump-using-a-navmeshagent-and-click-to-move-logic
     * Allows a NavMeshAgent to accept a velocity.
     * The NavMeshAgent is 'disable' while the RigidBody is 'enabled' during
     * the animation to avoid any clashes.
     */
    public class NavMeshVelocityManager : MonoBehaviour
    {
        private NavMeshAgent agent;
        private LivingEntityController controller;

        private Animator duckAnimator; // Reference to the Animator component

        private Rigidbody rb;

        private void Start()
        {
            rb = gameObject.GetComponent<Rigidbody>();
            agent = gameObject.GetComponent<NavMeshAgent>();

            ThrowIfInvalid();

            // duck
            if (gameObject.CompareTag("Player"))
            {
                duckAnimator = GetComponent<Animator>();
                if (duckAnimator is null) Debug.LogWarning("No Animator found on the Player!");
            }
        }

        //Detect entering and exiting water.
        private void OnTriggerEnter(Collider other)
        {
            if (!CompareTag("Player") && !CompareTag("Duckling")) return;
            if (agent == null) return;
            
            if (other.CompareTag("Water"))
            {
                agent.speed *= 0.8f;

                // Set swimming animation if duckAnimator is not null
                if (duckAnimator != null) controller.animator.SetBool("isSwimming", true);
            }

            if (other.CompareTag("Mud")) agent.speed *= 0.6f;
        }

        private void OnTriggerExit(Collider other)
        {
            if (!CompareTag("Player") && !CompareTag("Duckling")) return;
            if (other.CompareTag("Water"))
            {
                agent.speed = controller.GetDefaultSpeed();

                // Return to default animation if duckAnimator is not null
                if (duckAnimator != null) controller.animator.SetBool("isSwimming", false);
            }

            if (other.CompareTag("Mud")) agent.speed = controller.GetDefaultSpeed();
        }

        public void RegisterController(LivingEntityController livingEntityController)
        {
            controller = livingEntityController;
        }

        public void ThrowIfInvalid()
        {
            if (rb == null)
            {
                rb = gameObject.AddComponent<Rigidbody>();
                rb.isKinematic = true;
                rb.interpolation = RigidbodyInterpolation.None;
                rb.useGravity = false;
            }

            if (agent == null) throw new MissingComponentException("Missing NavMeshAgent on " + gameObject.name);
        }

        public void ApplyVelocity(Vector3 force, ForceMode mode, float animSeconds)
        {
            if (agent.enabled)
            {
                // lastDestination = agent.destination;

                // disable the agent
                agent.updatePosition = false;
                agent.updateRotation = false;
                agent.isStopped = true;
            }

            // make the jump
            rb.isKinematic = false;
            rb.useGravity = true;
            rb.AddForce(force, mode);

            StartCoroutine(FinishVelocity(animSeconds));
        }

        private IEnumerator FinishVelocity(float seconds)
        {
            yield return new WaitForSeconds(seconds);

            if (agent.enabled)
            {
                agent.Warp(rb.position);

                // if (lastDestination != Vector3.zero)
                // {
                //     agent.SetDestination(lastDestination);
                //     lastDestination = Vector3.zero;
                // }

                agent.updatePosition = true;
                agent.updateRotation = true;
                agent.isStopped = false;
            }

            rb.interpolation = RigidbodyInterpolation.None;
            rb.isKinematic = true;
            rb.useGravity = false;
        }
    }
}