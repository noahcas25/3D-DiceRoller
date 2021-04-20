using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    public GameObject dice;

    // Start is called before the first frame update
    void Start()
    {
        int rand1 = Random.Range(30, 180);
        int rand2 = Random.Range(30, 180);
        int rand3 = Random.Range(30, 180);

        dice.transform.Rotate(new Vector3(rand1, rand2, rand3)); 
    }

    public void Roll() {
        
        SceneManager.LoadScene("3D Dice");
    }

    public void Back() {
        SceneManager.LoadScene("SampleScene");
    }
}
