using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    float currentSpeed = 0f;
    [SerializeField] int maxHealth = 50;
    [SerializeField] Transform enemyPosition;
    [SerializeField] GameObject DeathVFX;
    [SerializeField] AudioClip DeathSFX;
    int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * currentSpeed);
    }

    public void SetMoveSpeed(float newSpeed)
    {
        currentSpeed = newSpeed;
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
            Die();
    }

    public void Die()
    {
        //Play death sound
        Instantiate(DeathVFX, enemyPosition.position, Quaternion.identity);
        //AudioSource.PlayClipAtPoint(DeathSFX, transform.position);
        Destroy(gameObject, 0.1f);
    }


}
