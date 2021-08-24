using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeScreen : MonoBehaviour
{
    public AudioSource soundSwitcher;
    public AudioClip start;
    public GameObject diceOverlay;


    private Animator anim;    
    private int diceIndex = 0;
    private int newIndex = 0;

    public void Start() {
        Application.targetFrameRate = 60;
        anim = GameObject.FindWithTag("TransitionImage").GetComponent<Animator>();
        anim.CrossFade("SceneSwitchIn", 0, 0, 0, 0);
        soundSwitcher.PlayOneShot(start);
    }

     void OnEnable() {
          if(PlayerPrefs.HasKey("diceIndex"))
                this.newIndex = PlayerPrefs.GetInt("diceIndex");

          setDice();
    }

    private void setDice() {
        diceOverlay.transform.GetChild(diceIndex).gameObject.SetActive(false);
        diceOverlay.transform.GetChild(newIndex).gameObject.SetActive(true);

        diceIndex = newIndex;
    }
    
    
    public void DiceRoll() {
        StartCoroutine(Transition("3D Dice"));

    }

    public void Shop() {
        StartCoroutine(Transition("Shop"));
    }

    private IEnumerator Transition(string scene) {
        anim.CrossFade("SceneSwitchOut", 0, 0, 0, 0);
        yield return new WaitForSeconds((float) 1);
        SceneManager.LoadScene(scene);
    }
}
