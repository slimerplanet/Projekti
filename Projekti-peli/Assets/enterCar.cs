using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enterCar : MonoBehaviour
{
    public GameObject player;
    public GameObject carExit;

    bool isInCar;

    public Behaviour[] carScrits;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            if (isInCar)
                exitCar();
            else
                entercar();
        }
    }

    void entercar()
    {
        setCarActive(true);
        player.SetActive(false);
        isInCar = true;
    }
    void exitCar()
    {
        setCarActive(false);
        player.SetActive(true);
        player.transform.position = carExit.transform.position;
        isInCar = false;

    }

    void setCarActive(bool value)
    {
        for (int i = 0; i < carScrits.Length; i++)
        {
            carScrits[i].enabled = value;
        }
    }
}
