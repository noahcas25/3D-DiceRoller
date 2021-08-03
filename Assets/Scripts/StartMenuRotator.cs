using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenuRotator : MonoBehaviour
{

    public bool isShop = false;
    private int posX;

    // Update is called once per frame
    void Update()
    {
        if(isShop) 
            this.transform.Rotate(new Vector3(0, 30, 0) * (float) 2 * Time.deltaTime);
        else
            this.transform.Rotate(new Vector3(0, 0, 20) * (float) 2 * Time.deltaTime);
    }


    public void setPosX(int value) {
        if(value > -730 && value < 1) {
            posX = value;
        }
    }

    public int getPosX() {
        return posX;
    }
}
