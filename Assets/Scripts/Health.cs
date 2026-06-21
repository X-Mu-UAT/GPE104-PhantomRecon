using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private bool isPlayer = false;
    private float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;

        // Sync UI at initialization phase
        if (isPlayer && UIManager.Instance != null)
        {
            UIManager.Instance.UpdateHealthBar(currentHealth, maxHealth);
        }
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;

        if (isPlayer && UIManager.Instance != null)
        {
            UIManager.Instance.UpdateHealthBar(currentHealth, maxHealth);
        }

        if (currentHealth <= 0f)
        {
            Die();
        }
    }

    private void Die()
    {
        if (isPlayer && UIManager.Instance != null)
        {
            UIManager.Instance.ShowGameOver();
        }

        Death deathComponent = GetComponent<Death>();
        if (deathComponent != null)
        {
            deathComponent.OnDeath();
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
