using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
   private bool paused = false;

    public void Switcher() {
        if(paused) 
            Resume();
        else
            Pause();
    }

    public void Pause() {
        transform.GetChild(0).gameObject.SetActive(true);
        Time.timeScale = 0f;
        paused = true;
    }

    public void Resume() {
        transform.GetChild(0).gameObject.SetActive(false);
        Time.timeScale = 1f;
        paused = false;
    }

     public void Shop() {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Shop");
    }

    public void Settings() {
        Resume();
           
    }

    public void Back() {
        Time.timeScale = 1f;
        SceneManager.LoadScene("3d Dice");
    }

    public void Quit() {
        Time.timeScale = 1f;
        Application.Quit();
    }
}
