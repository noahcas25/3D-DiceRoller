using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    public GameObject diceCamera;
    public GameObject dice;

    private Vector3 cameraPosition;
    private Vector3 dicePosition;

    public AudioSource soundSwitcher;
    public AudioClip start;

    // Start is called before the first frame update
    void Start()
    {
         soundSwitcher.PlayOneShot(start);
         cameraPosition = diceCamera.transform.position;
         dicePosition = dice.transform.position;
    }

    public void Roll() { 
        if(dice.transform.GetComponent<Dice>().canRoll) {

            dice.transform.GetComponent<Dice>().landed = false;

            int rand1 = Random.Range(30, 180);
            int rand2 = Random.Range(30, 180);
            int rand3 = Random.Range(30, 180);

            dice.transform.Rotate(new Vector3(rand1, rand2, rand3)); 

            setPositions();
        }
    }

    private void setPositions() {
        diceCamera.transform.position = cameraPosition;
        dice.transform.position = dicePosition;
    }

    public void Back() {
        SceneManager.LoadScene("SampleScene");
    }
}
