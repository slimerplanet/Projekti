using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class weaponicons : MonoBehaviour
{
    public weaponSwitching ws;
    public Image[] icons;
    public Color selectedColor;
    public Color unselectedColor;
    public int lastWeapon;
    private void Start()
    {
        updateIcons();
        lastWeapon = ws.selectedWeapon;
    }

    void Update()
    {
        if (ws.selectedWeapon != lastWeapon)
        {
            updateIcons();
            lastWeapon = ws.selectedWeapon;
        }
        else
            lastWeapon = ws.selectedWeapon;
    }

    void updateIcons()
    {
        icons[ws.selectedWeapon].color = selectedColor;
        for (int i = 0; i < icons.Length; i++)
        {
            if(i != ws.selectedWeapon)
            {
                icons[i].color = unselectedColor;
            }
        }
    }
}
