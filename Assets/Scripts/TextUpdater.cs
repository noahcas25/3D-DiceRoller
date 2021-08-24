using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InnerDriveStudios.DiceCreator;
using TMPro;


public class TextUpdater : MonoBehaviour
{

    private string diceSideUp;
    private GameObject dice;
    private bool landed;

    // Start is called before the first frame update
    void Start()
    {
        dice = GameObject.FindWithTag("Dice");
        diceSideUp = dice.GetComponent<DieSides>().GetDieSideMatchInfo().closestMatch.ToString();
    }
    
    // Update is called once per frame
    void Update()
    {
        if(dice.GetComponent<Dice>().getLanded() && diceSideUp != dice.GetComponent<DieSides>().GetDieSideMatchInfo().closestMatch.ToString()) {
            diceSideUp = dice.GetComponent<DieSides>().GetDieSideMatchInfo().closestMatch.ToString();
            GetComponent<TMPro.TextMeshProUGUI>().text = "" + diceSideUp[8];
            
            if(diceSideUp.Length > 9) {
            GetComponent<TMPro.TextMeshProUGUI>().text += diceSideUp[9];
            }  
        }
    }
}