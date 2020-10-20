using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroController : MonoBehaviour
{
    [SerializeField] GameObject[] introPanelsArray;
    int currentPanel = 0;

    private void Start()
    {
        foreach(GameObject introPanel in introPanelsArray)
        {
            introPanel.SetActive(false);
        }
        introPanelsArray[currentPanel].SetActive(true);
    }

    int LoadNextPanel(int panelIncrement)
    {
        currentPanel += panelIncrement;
        return currentPanel;
    }

    public void GoToNextPanel()
    {
        if (currentPanel >= introPanelsArray.Length - 1)
        {
            SceneManager.LoadScene("Loading Scene");
            return;
        }

        if(currentPanel < introPanelsArray.Length)
        {
            foreach (GameObject introPanel in introPanelsArray)
            {
                introPanel.SetActive(false);
            }
            introPanelsArray[LoadNextPanel(1)].SetActive(true);
        }
    }

    public void SkipIntro()
    {
        SceneManager.LoadScene("Loading Scene");
    }
}
