using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsMenu : MonoBehaviour
{

   // Function that changes the active canvas to the pauseMenuCanvas;
    public void Back() {
        transform.GetChild(0).gameObject.SetActive(true);  
        transform.GetChild(1).gameObject.SetActive(false);  
    }
}
