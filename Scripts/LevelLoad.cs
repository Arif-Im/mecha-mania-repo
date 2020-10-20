using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoad : MonoBehaviour
{
    [SerializeField] int timeToWait = 4;
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject optionsMenu;
    int currentSceneIndex;

    private void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex == 1)
        {
            StartCoroutine(DelayStartGame());
        }
    }

    IEnumerator DelayStartGame()
    {
        yield return new WaitForSeconds(timeToWait);
        SceneManager.LoadScene("Start Scene");
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Level 01");
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(currentSceneIndex);
    }


    public void LoadNextScene()
    {
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void GameOver()
    {
        SceneManager.LoadScene("Game Over");
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Start Scene");
    }

    public void OptionsMenu()
    {
        if (!mainMenu && !optionsMenu) { return; }
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void BackButton()
    {
        if (!mainMenu && !optionsMenu) { return; }
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }
}
