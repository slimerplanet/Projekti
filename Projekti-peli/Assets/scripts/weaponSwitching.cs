
using UnityEngine;

public class weaponSwitching : MonoBehaviour
{

    public int selectedWeapon = 0;
    pausemenu menu;

    void Start()
    {
        menu = FindObjectOfType<pausemenu>();
        selectWeapon();
    }

    void Update()
    {
        if (menu.paused)
            return;
   

        int previosSelectedWeapon = selectedWeapon;

        if(Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (selectedWeapon >= transform.childCount - 1)
                selectedWeapon = 0;
            else                  
                selectedWeapon++;
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (selectedWeapon <= 0)
                selectedWeapon = transform.childCount - 1;
            else
                selectedWeapon--;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
            selectedWeapon = 0;
        if (Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >= 2)
            selectedWeapon = 1;
        if (Input.GetKeyDown(KeyCode.Alpha3) && transform.childCount >= 3)
            selectedWeapon = 2;
        if (Input.GetKeyDown(KeyCode.Alpha4) && transform.childCount >= 4)
            selectedWeapon = 3;
        if (Input.GetKeyDown(KeyCode.Alpha5) && transform.childCount >= 5)
            selectedWeapon = 4;




        if (previosSelectedWeapon != selectedWeapon)
            selectWeapon();

    }


    void selectWeapon()
    {
        int i = 0;
        foreach(Transform weapon in transform)
        {
            if (i == selectedWeapon)
                weapon.gameObject.SetActive(true);
            else
                weapon.gameObject.SetActive(false);

            i++;
        }
    }
}
