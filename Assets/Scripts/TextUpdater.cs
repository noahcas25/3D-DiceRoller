using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InnerDriveStudios.DiceCreator;
using TMPro;


public class TextUpdater : MonoBehaviour
{

    // Global variables
    private string diceSideUp;
    private GameObject dice;
    private bool landed;

    // On start save the closestMatching diceSideUp to a variable
    void Start() {
        dice = GameObject.FindWithTag("Dice");
        diceSideUp = dice.GetComponent<DieSides>().GetDieSideMatchInfo().closestMatch.ToString();
    }
    
    
    // Updates the diceSideUp variable when the dice lands and changes the result text based on the result
    void Update() {
        if(dice.GetComponent<Dice>().GetLanded() && diceSideUp != dice.GetComponent<DieSides>().GetDieSideMatchInfo().closestMatch.ToString()) {
            diceSideUp = dice.GetComponent<DieSides>().GetDieSideMatchInfo().closestMatch.ToString();
            GetComponent<TMPro.TextMeshProUGUI>().text = "" + diceSideUp[8];
            
            if(diceSideUp.Length > 9) {
            GetComponent<TMPro.TextMeshProUGUI>().text += diceSideUp[9];
            }  
        }
    }
}