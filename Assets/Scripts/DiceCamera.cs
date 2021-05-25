using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceCamera : MonoBehaviour
{
    public GameObject dice;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - dice.transform.GetChild(0).position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = dice.transform.GetChild(0).position + offset;
    }
}
