using System.Collections;
using UnityEngine;

public class ProjectileHandler : MonoBehaviour
{
    // Define an event to handle collision
    public delegate void OnCollisionEnterDelegate(Collider other);

    private readonly float destroyDelay = 1f;

    private void Start()
    {
        // Start the destroy timer
        StartCoroutine(DestroyAfterDelay());
    }

    private void Update()
    {
        gameObject.transform.TransformDirection(Vector3.forward);
        gameObject.transform.Translate(new Vector3(0, 0, 30f * Time.deltaTime));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Duckling")) return;
        // Check if the collision is with an enemy (you can use tags or layers)
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Trigger the OnCollisionEnter event
            OnCollisionEnterEvent?.Invoke(collision.collider);
        }


        StopCoroutine(DestroyAfterDelay());

        // Destroy the projectile on collision
        Destroy(gameObject);
    }

    public event OnCollisionEnterDelegate OnCollisionEnterEvent;

    private IEnumerator DestroyAfterDelay()
    {
        yield return new WaitForSeconds(destroyDelay);

        // Destroy the projectile if no collision has occurred within the specified time
        Destroy(gameObject);
    }
}