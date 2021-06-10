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

    public void Settings() {
        
    }

    public void Quit() {
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1f;
    }
}
