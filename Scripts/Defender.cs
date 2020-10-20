using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Defender : MonoBehaviour
{
    [SerializeField] int starCost;

    public void AddStars(int amount)
    {
        FindObjectOfType<StarDisplay>().AddStar(amount);
    }

    public int GetStarCost()
    {
        return starCost;
    }
}
