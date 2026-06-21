using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed = 40f;
    [SerializeField] private float lifeSpan = 4f;
    private float damage;

    public void Initialize(float damageValue)
    {
        damage = damageValue;
        Destroy(gameObject, lifeSpan);
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        Health health = other.GetComponent<Health>();
        if (health != null)
        {
            health.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
