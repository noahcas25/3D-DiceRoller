using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopMenu : MonoBehaviour
{
    private Animator animator;
    private GameObject selectedDiceText;
    private GameObject palletCanvas;


    // PlayerSettings that are loaded on enable of the scene
    public void OnEnable() {
        animator = GameObject.FindWithTag("TransitionImage").GetComponent<Animator>();
        animator.CrossFade("SceneSwitchInShop", 0, 0, 0, 0);
        palletCanvas = GameObject.FindWithTag("PauseMenu");
        palletCanvas.SetActive(false);
        
        if(PlayerPrefs.HasKey("Volume")) {
               GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("Volume");
          }
    }
    
    // Transitions to the HomeScreen

    public void Back() {
        // Time.timeScale = 1f;
        StartCoroutine(Transition("HomeScreen"));
    }
    
    // Activates the pallet canvas in the shop

    public void MaterialPallet() {
        if(!palletCanvas.activeSelf)
            palletCanvas.SetActive(true);

        else palletCanvas.SetActive(false);

    }

    // Transitions to the Roll Scene

    public void RollButton() {
        // Time.timeScale = 1f;

        StartCoroutine(Transition("3D Dice"));
    }

    // Function that handles the transition animations and loads a new scene 
     private IEnumerator Transition(string scene) {
        animator.CrossFade("SceneSwitchOutShop", 0, 0, 0, 0);
        yield return new WaitForSeconds((float) 0.5);
        SceneManager.LoadScene(scene);
    }
}
