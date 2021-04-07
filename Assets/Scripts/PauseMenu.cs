using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject menu;

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Pause();
        }

    }
    
    void Pause() {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0;
        menu.SetActive(true);
    }

    public void UnPause() {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1;
        menu.SetActive(false);
    }

    public void MainMenuButton() {
        SceneManager.LoadScene("Menu");
    }


}
