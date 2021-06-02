using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{

    public bool landed = false;
    private bool canRoll = true;

    void Update()
    {
        if(!canRoll) {
            this.transform.Rotate(new Vector3(45, 45, 0) * (float) 3 * Time.deltaTime);
        } 
    }

    private void OnTriggerEnter(Collider other)
    {  
        if(other.CompareTag("Table")) {
            canRoll = true;
        }
    }

    //  private IEnumerator RollTimer() 
    // {
    //     yield return new WaitForSeconds((float) 2);
    //     canRoll = true;
    // }

    public void setCanRoll(bool value) {
        this.canRoll = value;
    }
    
    public bool getCanRoll() {
        return canRoll;
    }
}
