using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBot : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        GameObject otherGameObject = otherCollider.gameObject;

        if (otherGameObject.GetComponent<Defender>())
        {
            GetComponent<Animator>().SetTrigger("startAttackTrigger");
            GetComponent<Attacker>().Attack(otherGameObject);
        }
    }
}
