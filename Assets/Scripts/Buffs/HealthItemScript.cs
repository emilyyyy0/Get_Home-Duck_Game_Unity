using CombatSystem;
using UnityEngine;

public class HealthItemScript : MonoBehaviour
{
    public float height = 0.4f;
    public float speed = 2f;

    private Vector3 pos;

    // Start is called before the first frame update
    private void Start()
    {
        pos = transform.position;
    }

    // Update is called once per frame
    private void Update()
    {
        var newY = pos.y + Mathf.Sin(Time.time * speed) * height;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            var duckController = other.GetComponent<LivingEntityController>();
            if (duckController != null) duckController.ApplyFullHealth();

            var ducklings = FindObjectsOfType<DucklingController>();
            foreach (var duckling in ducklings) duckling.ApplyFullHealth();

            Destroy(gameObject);
        }
    }
}