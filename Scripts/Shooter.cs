using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] GameObject gun;
    GameObject projectileParent;
    AttackerSpawner myLaneSpawner;
    Animator anim;
    const string PROJECTILE_PARENT_NAME = "Projectile";

    private void Start()
    {
        SetLaneSpawner();
        CreateProjectileParent();
        anim = GetComponent<Animator>();
    }

    private void CreateProjectileParent()
    {
        projectileParent = GameObject.Find(PROJECTILE_PARENT_NAME);
        if (!projectileParent)
        {
            projectileParent = new GameObject(PROJECTILE_PARENT_NAME);
        }
    }

    private void Update()
    {
        if (IsAttackerInLane())
        {
            anim.SetBool("IsAttacking", true);
        }
        else
        {
            anim.SetBool("IsAttacking", false);
        }
    }

    private void SetLaneSpawner()
    {
        AttackerSpawner[] spawnerArray = FindObjectsOfType<AttackerSpawner>();

        foreach(AttackerSpawner spawner in spawnerArray)
        {
            bool isCloseEnough = Mathf.Abs(spawner.transform.position.y - transform.position.y) <= Mathf.Epsilon;
            if (isCloseEnough)
            {
                myLaneSpawner = spawner;
            }
        }
    }

    private bool IsAttackerInLane()
    {
        bool attackerInLane = myLaneSpawner.transform.childCount > 0;
        return attackerInLane;
    }

    public void Fire()
    {
        GameObject projectile = Instantiate(projectilePrefab, gun.transform.position, transform.rotation) as GameObject;
        projectile.transform.parent = projectileParent.transform;
    }
}
