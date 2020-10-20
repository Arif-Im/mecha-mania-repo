using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragBot : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        GameObject otherGameObject = otherCollider.gameObject;

        if (otherGameObject.GetComponent<WallBot>())
        {
            GetComponent<Animator>().SetTrigger("jumpTrigger");
        }
        else if (otherGameObject.GetComponent<Defender>())
        {
            GetComponent<Attacker>().Attack(otherGameObject);
        }
    }
}
