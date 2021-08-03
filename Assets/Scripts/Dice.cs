// using System.Runtime;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{

    private bool landed = false;
    private bool canRoll = false;
    private string DiceSideUp;

    private int rand1;
    private int rand2;
    private int rand3;
    private System.Random random = new System.Random();

    void Update()
    {
        if(!canRoll) {
            this.transform.Rotate(new Vector3(45, 45, 0) * (float) 3 * Time.deltaTime);
        } 
   }

   public void Randomize() {
       rand1 = (int) random.Next(1, 270);
       rand2 = (int) random.Next(1, 270);
       rand3 = (int) random.Next(1, 270);

        this.transform.Rotate(new Vector3(rand1, rand2, rand3));
   }

    private void OnTriggerEnter(Collider other)
    {  
        if(other.CompareTag("Table")) {
            canRoll = true;
            landed = true;
        }
    }

    public void setCanRoll(bool value) {
        this.canRoll = value;
    }

    public void setLanded(bool value) {
        this.landed = value;
    }
    
    public bool getCanRoll() {
        return canRoll;
    }

    public bool getLanded() {
        return landed;
    }
}
