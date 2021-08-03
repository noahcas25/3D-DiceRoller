using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeScreen : MonoBehaviour
{
    public AudioSource soundSwitcher;
    public AudioClip start;
    private int diceIndex = 0;
    // private int index = 0;

    public void Start() {
        Application.targetFrameRate = 60;
        soundSwitcher.PlayOneShot(start);

        // BinaryFormatter bf = new BinaryFormatter();

        // FileStream file = File.Create(Application.persistentDataPath + "/diceData.txt");
        // bf.Serialize(file, diceIndex);
        // file.Close();

    }

     void OnEnable() {
          if(PlayerPrefs.HasKey("diceIndex"))
                this.diceIndex = PlayerPrefs.GetInt("diceIndex");

          setDice(diceIndex);

            // billName = PlayerPrefs.GetString("BillName");
        //  if(File.Exists(Application.persistentDataPath + "/diceData.txt")) {
        //         file = File.Open(Application.persistentDataPath + "/diceData.txt", FileMode.Open);
        //         this.index = (int)bf.Deserialize(file);
        //         file.Close();
        // }
    }

    void OnDisable() {
        PlayerPrefs.SetInt("diceIndex", diceIndex);
        PlayerPrefs.Save();
    }

    private void setDice(int newIndex) {
        transform.GetChild(0).transform.GetChild(this.diceIndex).gameObject.SetActive(false);
        transform.GetChild(0).transform.GetChild(newIndex).gameObject.SetActive(true);

        this.diceIndex = newIndex;
    }
    
    
    public void Dice() {
        SceneManager.LoadScene("3D Dice");
    }

    public void Shop() {
        SceneManager.LoadScene("Shop");
    }
}
