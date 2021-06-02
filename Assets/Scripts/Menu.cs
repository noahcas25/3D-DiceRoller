using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Menu : MonoBehaviour
{
    public GameObject dice;
    private Vector3 dicePosition;

    private GameObject RollButton;
    private GameObject RollButtonChild;

    public AudioSource soundSwitcher;
    public AudioClip start;

    // Start is called before the first frame update
    void Start()
    {                 
         RollButton = GameObject.FindWithTag("RollButton");
         RollButtonChild = RollButton.transform.GetChild(1).gameObject;

         soundSwitcher.PlayOneShot(start);
         dicePosition = dice.transform.position;
    }

    public void Roll() 
    { 
        // RollButton.GetComponent<Button>().enabled = false;
        // RollButtonChild.GetComponent<Text>().enabled = false;

        if(dice.GetComponent<Dice>().getCanRoll()) {
            RollButton.GetComponent<Button>().enabled = false;
            RollButtonChild.GetComponent<TMPro.TextMeshProUGUI>().enabled = false;
            
            setPositions();
            dice.GetComponent<Dice>().setCanRoll(false);

            StartCoroutine(RollTimer());
        }
    }

     private IEnumerator RollTimer() 
    {
        yield return new WaitForSeconds((float) 5);

        RollButton.GetComponent<Button>().enabled = true;
        RollButtonChild.GetComponent<TMPro.TextMeshProUGUI>().enabled = true;
        dice.GetComponent<Dice>().setCanRoll(true);
    }

    private void setPositions() {
        dice.transform.position = dicePosition;
    }

    public void Back() {
        SceneManager.LoadScene("SampleScene");
    }
}
