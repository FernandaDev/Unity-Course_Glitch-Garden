using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;
    [SerializeField] int damageAmount = 10;

    private void Update()
    {
        transform.Translate(Vector2.right * Time.deltaTime * moveSpeed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        other.GetComponent<Damageable>()?.TakeDamage(damageAmount);

        this.gameObject.SetActive(false);
    }

}
