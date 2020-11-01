using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enterCar : MonoBehaviour
{
    public GameObject player;
    public GameObject carExit;

    public float enterRange = 5;

    bool isInCar;
    bool playerNextToCar;

    public Behaviour[] carScrits;

    // Start is called before the first frame update
    void Start()
    {
        setCarActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) 
        {
            if (isInCar)
                exitCar();
            else if (Vector3.Distance(transform.position, player.transform.position) <= enterRange)
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
