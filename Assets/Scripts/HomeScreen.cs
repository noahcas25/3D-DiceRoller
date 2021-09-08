using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HomeScreen : MonoBehaviour
{
    public GameObject diceOverlay;

    private GameObject CanvasOverlay;
    private GameObject VolumeSlider;
    private Animator anim;    
    private int diceIndex = 0;
    private int newIndex = 0;

    public void Start() {
        Application.targetFrameRate = 60;
        anim = GameObject.FindWithTag("TransitionImage").GetComponent<Animator>();
        anim.CrossFade("SceneSwitchInHomeScreen", 0, 0, 0, 0);
        CanvasOverlay = GameObject.FindWithTag("CanvasOverlay");
        VolumeSlider = transform.GetChild(1).GetChild(0).GetChild(4).gameObject;
    }

     void OnEnable() {
          if(PlayerPrefs.HasKey("diceIndex"))
                this.newIndex = PlayerPrefs.GetInt("diceIndex");

          setDice();
    }

    public void UpdateVolume() {
         GetComponent<AudioSource>().volume = VolumeSlider.GetComponent<Slider>().value;
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

    public void Options() {
        CanvasOverlay.transform.GetChild(0).gameObject.SetActive(false);
        CanvasOverlay.transform.GetChild(1).gameObject.SetActive(true);        
    }

    public void Back() {
        CanvasOverlay.transform.GetChild(0).gameObject.SetActive(true);
        CanvasOverlay.transform.GetChild(1).gameObject.SetActive(false);

    }

    private IEnumerator Transition(string scene) {
        anim.CrossFade("SceneSwitchOutHomeScreen", 0, 0, 0, 0);
        yield return new WaitForSeconds((float) 1);
        SceneManager.LoadScene(scene);
    }
}
