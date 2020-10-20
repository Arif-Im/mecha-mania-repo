using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class SlitherBot : MonoBehaviour
{
    [Range(0, 10)]
    [SerializeField] float probabilityToHit;

    [SerializeField] GameObject textParent;

    float hitDeterminant;

    public float ChanceForProjectileToHit()
    {
        hitDeterminant = Random.Range(0, 11);
        UnityEngine.Debug.Log(hitDeterminant);
        return hitDeterminant;
    }

    public bool DidProjectileHitSlitherBot()
    {
        bool isHit = hitDeterminant >= probabilityToHit;
        return isHit;
    }

    public void PlayHitAnimation()
    {
        textParent.GetComponent<Animator>().SetTrigger("HitTrigger");
    }

    public void PlayMissAnimation()
    {
        textParent.GetComponent<Animator>().SetTrigger("MissTrigger");
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
