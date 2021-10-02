using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
   private bool paused = false;
   private Animator animator;

    // Function that switches between pause and resume
    public void Switcher(Animator animIn) {
        this.animator = (Animator) animIn;
       
        if(paused) 
            Resume();
        else
            Pause();
    }

    // Function that "Pauses" the game, sets the pauseCanvas active and timeScale to 0
    public void Pause() {
        transform.GetChild(0).gameObject.SetActive(true);
        Time.timeScale = 0f;
        paused = true;
    }

    // Function that "Resumes" the game, disables the pauseCanvas and sets timeScale to 1
    public void Resume() {
        transform.GetChild(0).gameObject.SetActive(false);
        Time.timeScale = 1f;
        paused = false;
    }

    // Function that changes the active canvas to the settingsCanvas; SettingsMenu brings pauseCanvas back
    public void Settings() {
        transform.GetChild(0).gameObject.SetActive(false);  
        transform.GetChild(1).gameObject.SetActive(true);  
    }

    // Function that changes the active canvas to the pauseMenuCanvas;
    public void ReturnFromSettings() {
        transform.GetChild(0).gameObject.SetActive(true);  
        transform.GetChild(1).gameObject.SetActive(false);
    }

    // Transitions to the shop scene
     public void Shop() {
        Time.timeScale = 1f;
        StartCoroutine(Transition("Shop"));
    }

    // Transitions to the HomeScreen scene
    public void Back() {
        Time.timeScale = 1f;
        StartCoroutine(Transition("HomeScreen"));
    }

    // Function Exits the application
    public void Quit() {
        Time.timeScale = 1f;
        Application.Quit();
    }

     // Function that handles the transition animations and loads a new scene 
    private IEnumerator Transition(string scene) {
        animator.CrossFade("SceneSwitchOutDice", 0, 0, 0, 0);
        yield return new WaitForSeconds((float) 0.5);
        SceneManager.LoadScene(scene);
    }
}
