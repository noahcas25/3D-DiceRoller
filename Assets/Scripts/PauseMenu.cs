using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

   private bool paused = false;
   private Animator animator;

    public void Switcher(Animator anim) {
        this.animator = (Animator) anim;

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
        StartCoroutine(Transition("Shop"));
    }

    public void Settings() {
        Resume();  
    }

    public void Back() {
        Time.timeScale = 1f;
        StartCoroutine(Transition("HomeScreen"));
    }

    public void Quit() {
        Time.timeScale = 1f;
        Application.Quit();
    }

    private IEnumerator Transition(string scene) {
        animator.CrossFade("SceneSwitchOutDice", 0, 0, 0, 0);
        yield return new WaitForSeconds((float) 1);
        SceneManager.LoadScene(scene);
    }
}
