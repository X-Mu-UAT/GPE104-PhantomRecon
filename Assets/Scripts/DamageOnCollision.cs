using UnityEngine;

public class DamageOnCollision : MonoBehaviour
{
    [SerializeField] private float collisionDamge = 100f;// Instant kill on collision, can be adjusted for more nuanced damage if desired
   
    private void OnCollisionEnter(Collision collision)
    {
        // Check for component presence safely without errors
        Health health = collision.gameObject.GetComponent<Health>();
        if (health != null)
        {
            health.TakeDamage(collisionDamge);
        }
    }
}
