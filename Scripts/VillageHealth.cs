using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VillageHealth : MonoBehaviour
{
    [SerializeField] int health = 100;
    [SerializeField] Text healthText;
    bool playOnce = false;

    private void Start()
    {
        UpdateDisplay();
    }

    private void Update()
    {
        Die();
    }

    void Die()
    {
        if (health <= 0 && !playOnce)
        {
            FindObjectOfType<LevelController>().HandleLoseCondition();
            playOnce = true;
        }
    }

    private void UpdateDisplay()
    {
        healthText.text = health.ToString();
    }

    public void GetDamage(int damage)
    {
        health -= damage;
        UpdateDisplay();
    }
}
