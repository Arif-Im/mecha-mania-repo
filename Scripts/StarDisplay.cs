using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarDisplay : MonoBehaviour
{
    [SerializeField] int star = 0;
    Text starText;

    // Start is called before the first frame update
    void Start()
    {
        starText = GetComponent<Text>();
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        starText.text = star.ToString();
    }

    public bool HaveEnoughStars(int amount)
    {
        return star >= amount;
    }

    public void AddStar(int amount)
    {
        star += amount;
        UpdateDisplay();
    }

    public void SpendStar(int amount)
    {
        if (star >= amount)
        {
            star -= amount;
            UpdateDisplay();
        }
    }
}
