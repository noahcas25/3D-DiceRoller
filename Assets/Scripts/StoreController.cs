using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;
using Button = UnityEngine.UI.Button;

public class StoreController : MonoBehaviour
{

    private int numChildren;
    private int diceIndex = 0;
    private int newIndex = 0;
   
    void Start() {
        Application.targetFrameRate = 60;

        numChildren = transform.childCount;

        // Sets dice positions so that the camera knows where to point once dice buttons clicked

      for(int i = 0;  i  < numChildren - 1; i++) {
            transform.GetChild(i).GetComponent<StartMenuRotator>().setPosX(-145*i);
        }         
    }

    void OnEnable() {
          if(PlayerPrefs.HasKey("diceIndex"))
                this.newIndex = PlayerPrefs.GetInt("diceIndex");

          setDice();
    }

    void OnDisable() {
        PlayerPrefs.SetInt("diceIndex", diceIndex);
        PlayerPrefs.Save();
    }

    public void setDice() {
        transform.GetChild(6).transform.GetChild(diceIndex).gameObject.SetActive(false);
        transform.GetChild(6).transform.GetChild(newIndex).gameObject.SetActive(true);
        diceIndex = newIndex;
    }

    public void ButtonClicked(int index) {
        int buttonPosition = transform.GetChild(index).GetComponent<StartMenuRotator>().getPosX();
        transform.parent.gameObject.GetComponent<RectTransform>().localPosition = new Vector3(buttonPosition, 289, 0);

       newIndex = index;
       setDice();
    }
}
