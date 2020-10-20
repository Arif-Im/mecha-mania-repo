using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 5;
    [SerializeField] GameObject explosionPrefab;

    // Update is called once per frame
    void Update()
    {
        Die();
    }

    private void Die()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
            TriggerDeathVFX();
        }
    }

    private void TriggerDeathVFX()
    {
        if (!explosionPrefab) { return; }
        GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(explosion, 2f);
    }

    public void GetDamage(int damage)
    {
        health -= damage;
    }
}
