using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    [SerializeField] int damage = 3;
    [SerializeField] float projectileSpeed;

    private void Update()
    {
        transform.Translate(Vector2.left * projectileSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (FindObjectOfType<Defender>() != null)
        {
            if(collision.GetComponent<Health>() == null) { return; }
            collision.GetComponent<Health>().GetDamage(damage);
        }
    }
}
