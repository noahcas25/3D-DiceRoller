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

    public AudioSource soundSwitcher;
    public AudioClip start;
    private GameObject pauseMenu;

    // Start is called before the first frame update
    void Start()
    {
         pauseMenu = GameObject.FindWithTag("PauseMenu");
         rollButton = GameObject.FindWithTag("RollButton");
         rollButtonChild = rollButton.transform.GetChild(1).gameObject;

         soundSwitcher.PlayOneShot(start);
         
         dice = GameObject.FindWithTag("Dice");
         dicePosition = dice.transform.position;
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
        dice.transform.position = dicePosition;
    }


    public void PauseMenu() {
        pauseMenu.GetComponent<PauseMenu>().Switcher();
    }

    // public void Back() {
    //     SceneManager.LoadScene("SampleScene");
    // }
}
