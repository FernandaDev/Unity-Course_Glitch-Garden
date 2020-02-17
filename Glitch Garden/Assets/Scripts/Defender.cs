using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField] int starCost = 100;

    public int GetStarCost()
    {
        return starCost;
    }

    public void AddStarPoints(int amount)
    {
        GameManager.instance.AddStars(amount);
    }
}
