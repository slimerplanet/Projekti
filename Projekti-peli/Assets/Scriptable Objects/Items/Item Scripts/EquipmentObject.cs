using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Equipment Object", menuName = "Inventory System/Items/Equipment Object")]

public class EquipmentObject : ItemObject
{
    public float atkBonus;
    public float defenseBonus;
    public float healthBonus;
    public void Awake()
    {
        type = ItemType.Equipment;
    }
}
