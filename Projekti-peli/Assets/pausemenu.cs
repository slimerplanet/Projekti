using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pausemenu : MonoBehaviour
{
    public FirstPersonAIO controller;

    // Update is called once per frame
    void Update()
    {
        if(controller.controllerPauseState){
            Time.timeScale = 0;
        }
        else {
            Time.timeScale = 1;
        }
    }
}
