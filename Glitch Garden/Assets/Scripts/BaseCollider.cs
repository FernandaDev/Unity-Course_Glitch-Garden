using UnityEngine;

public class BaseCollider : MonoBehaviour
{
    [SerializeField] int damage = 10;

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (otherCollider.GetComponent<Attacker>())
        {
            GameManager.instance.RemoveLifePoints(damage);
            Destroy(otherCollider.gameObject, 0.1f);
        }
    }
}
