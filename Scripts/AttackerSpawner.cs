using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class AttackerSpawner : MonoBehaviour
{
    float spawnRate;
    [SerializeField] float minTime = 2f;
    [SerializeField] float maxTime = 3f;
    [SerializeField] Attacker[] attacker;
    LevelController levelController;
    bool spawn = true;
    Attacker chosenBot;

    IEnumerator Start()
    {
        do
        {
            if (!levelController)
                levelController = FindObjectOfType<LevelController>();
            yield return StartCoroutine(Spawn(SpawnAttackers()));
        }
        while (spawn);
    }

    public void StopSpawning()
    {
        spawn = false;
        StopAllCoroutines();
    }

    Attacker SpawnAttackers()
    {
        var random = Random.Range(0, attacker.Length);
        chosenBot = attacker[random];
        return chosenBot;
    }

    IEnumerator Spawn(Attacker myAttacker)
    {
        if (!levelController.DifficultyHasSet())
        {
            var setMinTime = minTime * PlayerPrefsController.DifficultyPercentage();
            var setMaxTime = maxTime * PlayerPrefsController.DifficultyPercentage();
            spawnRate = Random.Range(setMinTime, setMaxTime);
        }

        yield return new WaitForSeconds(spawnRate);

        Attacker newAttacker = Instantiate(myAttacker, transform.position, Quaternion.identity) as Attacker;
        newAttacker.transform.parent = transform;

        if (!levelController.DifficultyHasSet()) { levelController.IsDifficultySet(true); }
    }
}
