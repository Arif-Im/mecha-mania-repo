using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [Range(0, 5f)]
    [SerializeField] float currentSpeed = 0f;
    [SerializeField] int damageToVillage = 10;
    GameObject currentTarget;

    private void Awake()
    {
        FindObjectOfType<LevelController>().AddEnemies();
    }

    void OnDestroy()
    {
        LevelController levelController = FindObjectOfType<LevelController>();
        if (levelController != null)
        {
            levelController.RemoveEnemies();
        }
    }

    private void Update()
    {
        transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);
        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        if (!currentTarget)
        {
            GetComponent<Animator>().SetBool("IsAttacking", false);
        }
    }

    public void SetMovementSpeed(float speed)
    {
        currentSpeed = speed;
    }

    public void Attack(GameObject target)
    {
        GetComponent<Animator>().SetBool("IsAttacking", true);
        currentTarget = target;
    }

    public void StrikeCurrentTarget(int damage)
    {
        if(!currentTarget) { return; }
        Health health = currentTarget.GetComponent<Health>();
        if (health)
        {
            health.GetDamage(damage);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        VillageHealth village = collision.GetComponent<VillageHealth>();

        if (village)
        {
            village.GetDamage(damageToVillage);
            Destroy(gameObject);
        }
    }
}
