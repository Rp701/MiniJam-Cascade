using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    //type the name of the scene you want to load
    public string sceneToLoad;

    //this is the main menu panel
    public GameObject mainMenuPanel;
    //this is the credits panel
    public GameObject creditsPanel;

    //Load whatever scene sceneToLoad is called
    public void LoadLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneToLoad);
    }

    //Close the game if it's an exe file basically
    public void QuitGame()
    {
        Application.Quit();
    }

    //Disable/hide the main menu panel and enable Credits panel
    public void Credits()
    {
        mainMenuPanel.SetActive(false);
        creditsPanel.SetActive(true);
    }

    //Enable/show the main menu panel and disable/hide Credits panel
    public void MainMenu()
    {
        mainMenuPanel.SetActive(true);
        creditsPanel.SetActive(false);
    }

    private void Update()
    {
        //if you press escape, go back to the main menu
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            MainMenu();
        }
    }
}
