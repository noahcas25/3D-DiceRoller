using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Menu : MonoBehaviour
{
    private GameObject dice;
    private Vector3 dicePosition;
    private GameObject rollButton;
    private GameObject rollButtonChild;
    private int diceIndex = 0;
    private int newIndex = 0;

    public GameObject diceOverlay;
    public AudioSource soundSwitcher;
    public AudioClip start;
    private GameObject pauseMenu;

    // Start is called before the first frame update
    void Start()
    {
         Application.targetFrameRate = 60;
         pauseMenu = GameObject.FindWithTag("PauseMenu");
         rollButton = GameObject.FindWithTag("RollButton");
         rollButtonChild = rollButton.transform.GetChild(1).gameObject;
        
         soundSwitcher.PlayOneShot(start);
    }

    // OnEnable of Scene load the dice index from player prefs
    void OnEnable() {
          // Check if a dice has been selected and make that the index for setDice()
          if(PlayerPrefs.HasKey("diceIndex"))
                this.newIndex = PlayerPrefs.GetInt("diceIndex");
          
          setDice();

          dice = GameObject.FindWithTag("Dice");
          dicePosition = dice.transform.parent.transform.position;
          
          Roll();
          RollTimer();
    }

    void setDice() {
        // Deactivate the prevoius dice and activate the current index
        diceOverlay.transform.GetChild(diceIndex).gameObject.SetActive(false);
        diceOverlay.transform.GetChild(newIndex).gameObject.SetActive(true);
    }

    public void Roll() 
    { 
        if(dice.GetComponent<Dice>().getCanRoll()) {
            rollButton.GetComponent<Button>().enabled = false;
            rollButtonChild.GetComponent<TMPro.TextMeshProUGUI>().enabled = false;
            
            setPositions();
            dice.GetComponent<Dice>().setCanRoll(false);
            dice.GetComponent<Dice>().setLanded(false);

            StartCoroutine(RollTimer());
        }
    }

     private IEnumerator RollTimer() 
    {
        yield return new WaitForSeconds((float) 5);

        rollButton.GetComponent<Button>().enabled = true;
        rollButtonChild.GetComponent<TMPro.TextMeshProUGUI>().enabled = true;
        dice.GetComponent<Dice>().setCanRoll(true);
    }

    private void setPositions() {
        dice.GetComponent<Dice>().Randomize();
        dice.transform.parent.transform.position = dicePosition;
        dice.transform.position = dicePosition;
        dice.GetComponent<Rigidbody>().velocity = Vector3.zero;
        dice.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        dice.transform.parent.GetComponent<Rigidbody>().velocity = Vector3.zero;
        dice.transform.parent.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    }

    public void PauseMenu() {
        pauseMenu.GetComponent<PauseMenu>().Switcher();
    }

    public void Back() {
        SceneManager.LoadScene("HomeScreen");
    }
}
