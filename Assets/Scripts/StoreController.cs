using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;
using Button = UnityEngine.UI.Button;

public class StoreController : MonoBehaviour
{

    private int numChildren;
    private int index = 0;

    private BinaryFormatter bf = new BinaryFormatter();
    private FileStream file;
   
   
    void Start() {
      
        numChildren = transform.childCount;

      for(int i = 0;  i  < numChildren; i++) {
            transform.GetChild(i).GetComponent<StartMenuRotator>().setPosX(-145*i);
        }         
    }

    void OnLoad() {
        LoadSave();
    }

    public void LoadSave() {
        if(File.Exists(Application.persistentDataPath + "/diceData.txt")) {
                file = File.Open(Application.persistentDataPath + "/diceData.txt", FileMode.Open);
                index = (int)bf.Deserialize(file);
                file.Close();
        }
    }

    public void ButtonClicked(int index) {
        
        int buttonPosition = transform.GetChild(index).GetComponent<StartMenuRotator>().getPosX();

       transform.parent.gameObject.GetComponent<RectTransform>().localPosition = new Vector3(buttonPosition, 289, 0);

    }
}
