using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventorySystem : MonoBehaviour
{
    [Header(" ")]
    public bool hasPistol;
    public bool hasMachete;
    public bool hasBomb;
    [Header(" ")]
    public GameObject Pistol;
    public GameObject machete;
    public GameObject Bomb;
    public GameObject Hands;

    public Transform holder;
    public Transform unactiveHolder;

    private void Update()
    {
        if (hasPistol)
            Pistol.transform.parent = holder;
        else
        {
            Pistol.transform.parent = unactiveHolder;
            Pistol.SetActive(false);
        }

        if (hasMachete)
            machete.transform.parent = holder;
        else
        {
            machete.transform.parent = unactiveHolder;
            machete.SetActive(false);
        }

        if (hasBomb)
            Bomb.transform.parent = holder;
        else
        {
            Bomb.transform.parent = unactiveHolder;
            Bomb.SetActive(false);
        }

        if(!hasBomb && !hasMachete && !hasPistol)
        {
            Hands.transform.parent = holder;


        }
        else
        {
            Hands.SetActive(false);
            Hands.transform.parent = unactiveHolder;
            
        }

    }
}
