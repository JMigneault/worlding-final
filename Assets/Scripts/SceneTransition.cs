using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject creditsMenu;
    
    public void StartButton() {
        SceneManager.LoadScene("TestRoom");
    }

    public void CreditsButton() {
        mainMenu.SetActive(false);
        creditsMenu.SetActive(true);
    }

    public void MainMenuButton() {
        mainMenu.SetActive(true);
        creditsMenu.SetActive(false);
    }

    public void QuitButton() {
        Application.Quit();
    }

}
