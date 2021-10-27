using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Menu : MonoBehaviour
{
    // Global Variables
    private GameObject dice;
    private Vector3 dicePosition;
    private GameObject rollButton;
    private GameObject rollButtonChild;
    private GameObject bg;
    private GameObject volumeSlider;
    private float volume = 0;
    private int diceIndex = 0;
    private int newIndex = 0;

    public GameObject diceOverlay;
    private GameObject pauseMenu;
    private Animator anim; 

    // Ad variables
    public AdsManager ads;
    private int adCounter;

    // Start is called before the first frame update
    void Start()
    {
         Application.targetFrameRate = 60;
         pauseMenu = GameObject.FindWithTag("PauseMenu");
         rollButton = GameObject.FindWithTag("RollButton");
         rollButtonChild = rollButton.transform.GetChild(1).gameObject;
         volumeSlider = pauseMenu.transform.GetChild(1).GetChild(2).gameObject;

         anim = GameObject.FindWithTag("TransitionImage").GetComponent<Animator>();
         anim.CrossFade("SceneSwitchInDice", 0, 0, 0, 0);
         adCounter = 0;
    }

    // PlayerSettings that are loaded on enable of the scene *
    void OnEnable() {

          bg = GameObject.FindWithTag("Backgrounds");

          // Load playerPrefs on startUp
          if(PlayerPrefs.HasKey("diceIndex"))
                this.newIndex = PlayerPrefs.GetInt("diceIndex");
                
          if(PlayerPrefs.HasKey("Volume")) {
               volume = PlayerPrefs.GetFloat("Volume");
               GetComponent<AudioSource>().volume = volume;
          }

          if(PlayerPrefs.HasKey("BgColor")) 
               BackgroundChange(PlayerPrefs.GetString("BgColor"));

        // Load the selected dice, save the position and turn off gravity settings for dice and its overlay
          SetDice();
          dice = GameObject.FindWithTag("Dice");
          dicePosition = dice.transform.parent.transform.position;
          dice.GetComponent<Rigidbody>().useGravity = false;
          diceOverlay.GetComponent<Rigidbody>().useGravity = false;

          if(PlayerPrefs.HasKey("materialName"))
                ChangeMaterial(PlayerPrefs.GetString("materialName"));

    }

    // Player settings that are saved on disable of the scene
     void OnDisable() {
        PlayerPrefs.SetFloat("Volume", volume);
        PlayerPrefs.Save();
    }

    // Sets the selected dice as the active one
    void SetDice() {
        diceOverlay.transform.GetChild(diceIndex).gameObject.SetActive(false);
        diceOverlay.transform.GetChild(newIndex).gameObject.SetActive(true);
    }

    // Function that rolls the dice
    public void Roll() 
    { 
        if(dice.GetComponent<Dice>().GetCanRoll()) {
            adCounter++;

            //  Plays ad every 8th roll
            if(adCounter%8==0) {
                ads.PlayAd();
            }
            
            // adjusts dice physics on roll
            diceOverlay.transform.rotation = Quaternion.identity;
            dice.GetComponent<Rigidbody>().useGravity = true;
            diceOverlay.GetComponent<Rigidbody>().useGravity = true;
            diceOverlay.GetComponent<Rigidbody>().AddForce(35, -20, 35, ForceMode.Impulse);
            dice.GetComponent<Rigidbody>().AddForce(35, -20, 35, ForceMode.Impulse);
            
            // disable roll buttons
            rollButton.GetComponent<Button>().enabled = false;
            rollButtonChild.GetComponent<TMPro.TextMeshProUGUI>().enabled = false;
            
            // position the dice and disable roll function 
            SetPositions();
            dice.GetComponent<Dice>().SetCanRoll(false);
            dice.GetComponent<Dice>().SetLanded(false);

            StartCoroutine(RollTimer());
        }
    }

    // Timer that reinstates the roll function after 4 seconds
     private IEnumerator RollTimer() 
    {
        yield return new WaitForSeconds((float) 4);
        
        rollButton.GetComponent<Button>().enabled = true;
        rollButtonChild.GetComponent<TMPro.TextMeshProUGUI>().enabled = true;
        dice.GetComponent<Dice>().SetCanRoll(true);
    }

    // Function that prepares dice for roll
    private void SetPositions() {
        dice.GetComponent<Dice>().Randomize();
        diceOverlay.transform.position = dicePosition;
        dice.transform.position = dicePosition;
        dice.GetComponent<Rigidbody>().velocity = Vector3.zero;
        dice.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        diceOverlay.GetComponent<Rigidbody>().velocity = Vector3.zero;
        diceOverlay.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    }

    // Function used by the volumeSlider to adjust audiosource's volume
    public void UpdateVolume() {
         volume = volumeSlider.GetComponent<Slider>().value;
         GetComponent<AudioSource>().volume = volume;
    }

    // Disables all backgrounds and enables the selected one through a switch statement *
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
    

    // Changes the ActiveDices Material

    public void ChangeMaterial(string matName) {
        dice.GetComponent<MeshRenderer>().material = Resources.Load(matName + "/" + dice.gameObject.name + "_" + matName + "Material", typeof(Material)) as Material;
    }


    // Calls the pausemenu switcher method that pauses the game
    public void PauseMenu() {
        volumeSlider.GetComponent<Slider>().value = volume;
        pauseMenu.GetComponent<PauseMenu>().Switcher(anim);
    }

    // Transitions to the HomeScreen scene
    public void Back() {
       StartCoroutine(Transition("HomeScreen"));
    }
    
    // Function that handles the transition animations and loads a new scene 
    private IEnumerator Transition(string scene) {
        anim.CrossFade("SceneSwitchOutDice", 0, 0, 0, 0);
        yield return new WaitForSeconds((float) 0.5);
        SceneManager.LoadScene(scene);
    }
}
