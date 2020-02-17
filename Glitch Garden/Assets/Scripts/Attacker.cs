using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Attacker : MonoBehaviour
{
    float currentSpeed = 0f;
    Transform currentTarget;

    Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        GameManager.instance.AddAttackerCount();
    }

    private void OnDestroy()
    {
        GameManager.instance.RemoveAttackerCount();
    }

    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * currentSpeed);

        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        if (!currentTarget)
            anim.SetBool("IsAttacking", false);
    }

    public void SetMoveSpeed(float newSpeed)
    {
        currentSpeed = newSpeed;
    }

    public void Attack(Transform target)
    {
        anim.SetBool("IsAttacking", true);
        currentTarget = target;
    }

    public void StrikeCurrentTarget(int damage)
    {
        if (!currentTarget) return;

        Damageable damageable = currentTarget.GetComponent<Damageable>();

        if(damageable)
        {
            damageable.TakeDamage(damage);
        }
    }
}
