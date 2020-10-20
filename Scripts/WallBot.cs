using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBot : MonoBehaviour
{
    GameObject enemy;
    bool playOnce = false;

    private void Update()
    {
        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        if (!enemy)
        {
            if(!playOnce)
                GetComponent<Animator>().SetBool("IsBlocking", false);
            playOnce = true;
        }
    }

    private void OnTriggerStay2D(Collider2D otherCollider)
    {
        Attacker attacker = otherCollider.GetComponent<Attacker>();

        enemy = attacker.gameObject;

        if (attacker)
        {
            GetComponent<Animator>().SetTrigger("startBlockTrigger");
            GetComponent<Animator>().SetBool("IsBlocking", true);
            playOnce = false;
        }
    }
}
