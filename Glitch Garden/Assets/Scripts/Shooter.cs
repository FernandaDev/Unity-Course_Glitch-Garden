using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] Transform shootTransform;
    Animator anim;
    Transform myLaneSpawner;

    private void Start()
    {
        anim = GetComponent<Animator>();
        SetLaneSpawner();
    }

    private void Update()
    {
        HandleAnimations();
    }

    private void HandleAnimations()
    {
        if (IsAttackerInLane())
        {
            anim.SetBool("ShouldAttack", true);
        }
        else
        {
            anim.SetBool("ShouldAttack", false);
        }
    }

    private bool IsAttackerInLane()
    {
        if (myLaneSpawner.childCount > 0) return true;
        
        return false;
    }

    private void SetLaneSpawner()
    {
        foreach (var spawnPoint in AttackerSpawner.instance.spawnPoints)
        {
            if (Mathf.Abs(spawnPoint.position.y - transform.position.y) <= Mathf.Epsilon)
            {
                myLaneSpawner = spawnPoint;
            }
        }
    }

    public void Shoot()
    {
        Instantiate(projectilePrefab, shootTransform.position, Quaternion.identity);
    }
}
