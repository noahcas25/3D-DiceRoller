// using System.Runtime;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{

    // Global Variables
    private bool landed = false;
    private bool canRoll = true;
    private string DiceSideUp;
    private bool selected;

    // random #s for new dice angle
    private int rand1;
    private int rand2;
    private int rand3;
    private System.Random random = new System.Random();

    // Update is called once per frame
    void Update()
    {
        if(!canRoll) {
            this.transform.parent.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            this.transform.parent.transform.Rotate(new Vector3(45, 0, -45) * (float) 6 * Time.deltaTime);
        } 
   }

    // Function that randomizes the dices angle
   public void Randomize() {
       rand1 = (int) random.Next(1, 120);
       rand2 = (int) random.Next(1, 120);
       rand3 = (int) random.Next(1, 120);

        this.transform.Rotate(new Vector3(rand1, rand2, rand3));
   }

    // Trigger for collision with table, sets variables true
    private void OnTriggerEnter(Collider other)
    {  
        if(other.CompareTag("Table")) {
            this.transform.parent.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
            canRoll = true;
            landed = true;
        }
    }

    // Function that sets variable canRoll
    public void setCanRoll(bool value) {
        this.canRoll = value;
    }

    // Function that sets variable landed
    public void setLanded(bool value) {
        this.landed = value;
    }
    
    // returns canRoll variable
    public bool getCanRoll() {
        return canRoll;
    }

    // returns landed variable
    public bool getLanded() {
        return landed;
    }
}
