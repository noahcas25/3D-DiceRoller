using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceCamera : MonoBehaviour
{
    private GameObject dice;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        dice = GameObject.FindWithTag("Dice");
        offset = transform.position - dice.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = dice.transform.position + offset;
    }
}
