using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] int damage = 3;
    [SerializeField] float projectileSpeed;

    private void Update()
    {
        transform.Translate(Vector2.right * projectileSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (FindObjectOfType<SlitherBot>() != null)
        {
            collision.GetComponent<SlitherBot>().ChanceForProjectileToHit();
            if (collision.GetComponent<SlitherBot>().DidProjectileHitSlitherBot())
            {
                if (FindObjectOfType<Attacker>() != null)
                {
                    collision.GetComponent<SlitherBot>().PlayHitAnimation();
                    collision.GetComponent<Health>().GetDamage(damage);
                    Destroy(gameObject);
                }
            }
            else if (!collision.GetComponent<SlitherBot>().DidProjectileHitSlitherBot())
            {
                collision.GetComponent<SlitherBot>().PlayMissAnimation();
            }
        }
        else if (FindObjectOfType<Attacker>() != null)
        {
            if (collision.GetComponent<Health>() == null) { return; }
            collision.GetComponent<Health>().GetDamage(damage);
            Destroy(gameObject);
        }
    }
}
