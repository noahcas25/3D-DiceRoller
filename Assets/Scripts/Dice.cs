using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{

    public bool landed = false;
    public bool canRoll;

    void Update()
    {
        if(!landed) {
            this.transform.Rotate(new Vector3(45, 45, 0) * (float) 2.5 * Time.deltaTime);
            canRoll = false;
        } 
    }

    private void OnTriggerEnter(Collider other)
    {  
        if(other.CompareTag("Table")) {
            landed = true; 
            StartCoroutine(RollTimer());
        }
    }

     private IEnumerator RollTimer() 
    {
        yield return new WaitForSeconds((float) 2);
        canRoll = true;
    }
}
