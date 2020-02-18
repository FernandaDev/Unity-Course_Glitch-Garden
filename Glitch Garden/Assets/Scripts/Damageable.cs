using UnityEngine;

public class Damageable : MonoBehaviour
{
    [SerializeField] Transform transformOffset;
    [SerializeField] int maxHealth = 50;
    [SerializeField] GameObject DeathVFX;
    [SerializeField] AudioClip DeathSFX;
    
    int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
            Die();
    }

    public void Die()
    {
        if(transformOffset!= null)
            Instantiate(DeathVFX, transformOffset.position, Quaternion.identity, transformOffset);
        else
            Instantiate(DeathVFX, transform.position, Quaternion.identity, transform);
        
        Destroy(gameObject, 0.1f);
    }
}
