using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HomeScreen : MonoBehaviour
{
    // Global Variables
    public GameObject diceOverlay;
    private GameObject canvasOverlay;
    private GameObject volumeSlider;
    private GameObject bg;
    private Animator anim;    
    private float volume = 0;
    private int diceIndex = 0;
    private int newIndex = 0;
    private string color;

    // variables that are set when application is started
    public void Start() {
        Application.targetFrameRate = 60;
        anim = GameObject.FindWithTag("TransitionImage").GetComponent<Animator>();
        canvasOverlay = GameObject.FindWithTag("CanvasOverlay");

        anim.CrossFade("SceneSwitchInHomeScreen", 0, 0, 0, 0);
        volume = GetComponent<AudioSource>().volume;
        volumeSlider = transform.GetChild(1).GetChild(0).GetChild(3).gameObject;
    }

    // PlayerSettings that are loaded on enable of the scene
     void OnEnable() {
            bg = GameObject.FindWithTag("Backgrounds");

          if(PlayerPrefs.HasKey("diceIndex"))
                this.newIndex = PlayerPrefs.GetInt("diceIndex");

          if(PlayerPrefs.HasKey("Volume")) {
               volume = PlayerPrefs.GetFloat("Volume");
               GetComponent<AudioSource>().volume = volume;
          }

          if(PlayerPrefs.HasKey("BgColor")) {
               BackgroundChange(PlayerPrefs.GetString("BgColor"));
          }

           if(PlayerPrefs.HasKey("materialName"))
                ChangeMaterial(PlayerPrefs.GetString("materialName"));

          setDice();
    }

    // Player settings that are saved on disable of the scene
     void OnDisable() {
        PlayerPrefs.SetFloat("Volume", volume);
        PlayerPrefs.Save();
    }

    // Sets the selected dice as the active one
    private void setDice() {
        diceOverlay.transform.GetChild(diceIndex).gameObject.SetActive(false);
        diceOverlay.transform.GetChild(newIndex).gameObject.SetActive(true);

        diceIndex = newIndex;
    }

    // Function used by the volumeSlider to adjust audiosource's volume
    public void UpdateVolume() {
        volume = volumeSlider.GetComponent<Slider>().value;
         GetComponent<AudioSource>().volume = volume;
    }

    // Disables all backgrounds and enables the selected one through a switch statement
    public void BackgroundChange(string color) {

            bg.transform.GetChild(0).gameObject.SetActive(false);
            bg.transform.GetChild(1).gameObject.SetActive(false);
            bg.transform.GetChild(2).gameObject.SetActive(false);

        switch(color) {
            case "red": 
                bg.transform.GetChild(0).gameObject.SetActive(true);
            break;
            case "green":
                bg.transform.GetChild(1).gameObject.SetActive(true);
            break;
            default: 
                bg.transform.GetChild(2).gameObject.SetActive(true);
            break;
        }

        PlayerPrefs.SetString("BgColor", color);
    }

    // Handles the MaterialButton Function

    public void ChangeMaterial(string matName) {
        diceOverlay.transform.GetChild(newIndex).GetComponent<MeshRenderer>().material = Resources.Load(matName + "/" + diceOverlay.transform.GetChild(newIndex).gameObject.name + "_" + matName + "Material", typeof(Material)) as Material;
    }

    //  Function that sets the option canvas as the active canvas on screen and disables the start canvas
    public void Options() {
        diceOverlay.SetActive(false);
        canvasOverlay.transform.GetChild(0).gameObject.SetActive(false);
        canvasOverlay.transform.GetChild(1).gameObject.SetActive(true);    
        volumeSlider.GetComponent<Slider>().value = volume;    
    }

    // Function that sets the start canvas as the active canvas on screen and disables the option canvas
    public void Back() {
        diceOverlay.SetActive(true);
        canvasOverlay.transform.GetChild(0).gameObject.SetActive(true);
        canvasOverlay.transform.GetChild(1).gameObject.SetActive(false);
    }

     // Transitions to the dice rolling scene
    public void DiceRoll() {
        StartCoroutine(Transition("3D Dice"));
    }

    // Transitions to the shop scene
    public void Shop() {
        StartCoroutine(Transition("Shop"));
    }

    // Function that handles the transition animations and loads a new scene 
    private IEnumerator Transition(string scene) {
        anim.CrossFade("SceneSwitchOutHomeScreen", 0, 0, 0, 0);
        yield return new WaitForSeconds((float) 0.5);
        SceneManager.LoadScene(scene);
    }
}
