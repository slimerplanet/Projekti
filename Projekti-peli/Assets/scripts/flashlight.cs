using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flashlight : MonoBehaviour
{
    public Light torch;
    public KeyCode flashLightKey;

    bool isOn = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(flashLightKey))  {
            isOn = !isOn;
        }

        torch.enabled = isOn;
    }
}
