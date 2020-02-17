using UnityEngine;

public class Fox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        Transform other = otherCollider.transform;

        if (other.GetComponent<Gravestone>())
            GetComponent<Animator>().SetTrigger("Jump");
        else if (other.GetComponent<Defender>())
            GetComponent<Attacker>().Attack(other);
    }
}
