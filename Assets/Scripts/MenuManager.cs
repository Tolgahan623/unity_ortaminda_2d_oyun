using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    public GameObject InfoPanel;
    private bool isPanelOn;

    public void Play(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Options(){
        SceneManager.LoadScene("SettingsMenu");
    }

    public void Quit(){
        Application.Quit();
    }

    public void InfoText()
    {
        if (isPanelOn)
        {
            InfoPanel.SetActive(false);

            isPanelOn = !isPanelOn;
        }
        else
        {
            InfoPanel.SetActive(true);

            isPanelOn = !isPanelOn;
        }
    }
}
