using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;
using Button = UnityEngine.UI.Button;

public class StoreController : MonoBehaviour
{
    // Global Variables
    private int diceCount = 7;
    private int diceIndex = 0;
    private int newIndex = 0;
    private GameObject bg;
    private GameObject selectedText;
    private string materialName;
   
   // variables that are set when application is started
    void Start() {
        Application.targetFrameRate = 60;
        diceCount = transform.childCount;

        // Sets dice positions for the camera to track when the dice buttons are clicked
      for(int i = 0;  i  < diceCount - 1; i++) {
            transform.GetChild(i).GetComponent<StartMenuRotator>().setPosX(((-145*i)+(-3)));
        }         
    }

    // PlayerSettings that are loaded on enable of the scene
    void OnEnable() {
        bg = GameObject.FindWithTag("Backgrounds");
        selectedText = GameObject.FindWithTag("SelectedDiceText");

          if(PlayerPrefs.HasKey("diceIndex"))
                this.newIndex = PlayerPrefs.GetInt("diceIndex");

          if(PlayerPrefs.HasKey("BgColor"))
                BackgroundChange(PlayerPrefs.GetString("BgColor"));

          if(PlayerPrefs.HasKey("materialName"))
                ChangeMaterial(PlayerPrefs.GetString("materialName"));
          else
                materialName = "WhiteOnBlackMatte";

          ButtonClicked(newIndex);
    }

    // PlayerSettings that are saved on disable of the scene
    void OnDisable() {
        PlayerPrefs.SetInt("diceIndex", diceIndex);
        PlayerPrefs.SetString("materialName", materialName);
        PlayerPrefs.Save();

    }

    // Sets the selected dice as the active one
    private void SetDice() {
        // turns on the indicator for the selected dice
        transform.GetChild(6).transform.GetChild(diceIndex).gameObject.SetActive(false);
        transform.GetChild(6).transform.GetChild(newIndex).gameObject.SetActive(true);

        diceIndex = newIndex;
    }

    // Disables all backgrounds and enables the selected one through a switch statement
    private void BackgroundChange(string color) {

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
    }

    // Function that sets the selected dice and changes camera position
    public void ButtonClicked(int index) {

        int buttonPosition = transform.GetChild(index).GetComponent<StartMenuRotator>().getPosX();
        transform.parent.gameObject.GetComponent<RectTransform>().localPosition = new Vector3(buttonPosition, 289, 0);

       newIndex = index;
       SetDice();

    //    Updates SelectedDiceText
       selectedText.GetComponent<TMPro.TextMeshProUGUI>().text = SelectedDiceInfo();
    }

    // Handles the MaterialButton Function

    public void ChangeMaterial(string matName) {
        
        for(int i = 0; i < (diceCount - 1); i++) {
            transform.GetChild(i).GetComponent<MeshRenderer>().material = Resources.Load(matName + "/" + transform.GetChild(i).gameObject.name + "_" + matName + "Material", typeof(Material)) as Material;
        }

        materialName = matName;
    }

    // Changes the text above the roll button based on which dice is chosen

    public string SelectedDiceInfo(){
         switch(newIndex){
             case 0: return "Round";
             break;
             case 1: return "Square";
             break;
             case 2: return "8 Sided";
             break;
             case 3: return "10 Sided";
             break;
             case 4: return "12 Sided";
             break;
             case 5: return "20 Sided";
             break;
             default: return "Rounded";
         }
    }
}