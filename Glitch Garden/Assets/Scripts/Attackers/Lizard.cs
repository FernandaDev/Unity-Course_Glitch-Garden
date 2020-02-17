using UnityEngine;

public class Lizard : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        Transform other = otherCollider.transform;

        if (other.GetComponent<Defender>())
            GetComponent<Attacker>().Attack(other);
    }

}
