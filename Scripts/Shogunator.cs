using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shogunator : MonoBehaviour
{
    [SerializeField] GameObject enemyProjectilePrefab;
    [SerializeField] GameObject sword;
    GameObject enemyProjectileParent;
    const string PROJECTILE_PARENT_NAME = "Enemy Projectile";

    // Start is called before the first frame update
    void Start()
    {
        CreateProjectileParent();
    }

    private void CreateProjectileParent()
    {
        enemyProjectileParent = GameObject.Find(PROJECTILE_PARENT_NAME);
        if (!enemyProjectileParent)
        {
            enemyProjectileParent = new GameObject(PROJECTILE_PARENT_NAME);
        }
    }

    public void Fire()
    {
        GameObject projectile = Instantiate(enemyProjectilePrefab, sword.transform.position, transform.rotation) as GameObject;
        projectile.transform.parent = enemyProjectileParent.transform;
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        GameObject otherGameObject = otherCollider.gameObject;

        if (otherGameObject.GetComponent<Defender>())
        {
            GetComponent<Attacker>().Attack(otherGameObject);
        }
    }
}
