using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] AudioClip winMusic;
    [SerializeField] AudioClip loseMusic;
    [SerializeField] GameObject winLabel;
    [SerializeField] GameObject loseLabel;
    [SerializeField] int timeLoadNextLevel = 4;
    bool difficultySet = false;
    int numberOfEnemies = 0;
    bool timerHasEnded = false;
    bool playEndLevelOnce = false;

    private void Start()
    {
        IsDifficultySet(false);
        winLabel.SetActive(false);
        loseLabel.SetActive(false);
    }

    private void Update()
    {
        EndTheLevelAtEndTime();
    }

    private void EndTheLevelAtEndTime()
    {
        if (timerHasEnded && numberOfEnemies <= 0)
        {
            if (!playEndLevelOnce)
            {
                if (!winLabel) { return; }
                StartCoroutine(HandleWinCondition());
                playEndLevelOnce = true;
            }
        }
    }

    public bool EndGame()
    {
        return numberOfEnemies <= 0;
    }

    public void AddEnemies()
    {
        numberOfEnemies++;
    }

    public void RemoveEnemies()
    {
        numberOfEnemies--;
    }

    public void TimerHasFinished()
    {
        timerHasEnded = true;
        StopSpawners();
    }

    private void StopSpawners()
    {
        AttackerSpawner[] spawnerArray = FindObjectsOfType<AttackerSpawner>();
        foreach(AttackerSpawner spawner in spawnerArray)
        {
            spawner.StopSpawning();
        }
    }

    IEnumerator HandleWinCondition()
    {
        winLabel.SetActive(true);
        AudioSource.PlayClipAtPoint(winMusic, Camera.main.transform.position);
        yield return new WaitForSeconds(timeLoadNextLevel);
        GetComponent<LevelLoad>().LoadNextScene();
    }

    public void HandleLoseCondition()
    {
        Time.timeScale = 0f;
        loseLabel.SetActive(true);
        AudioSource.PlayClipAtPoint(loseMusic, Camera.main.transform.position);
    }


    public void IsDifficultySet(bool difficulty)
    {
        difficultySet = difficulty;
    }

    public bool DifficultyHasSet()
    {
        return difficultySet;
    }
}
