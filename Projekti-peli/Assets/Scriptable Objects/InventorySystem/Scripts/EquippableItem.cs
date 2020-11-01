using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EquipmentType
{
    Helmet,
    Chest,
    Gloves,
    Boots,
    Weapon1,
    Weapon2,
}

[CreateAssetMenu]
public class EquippableItem : Item
{
    public int Damage;
    public int DamageResistance;
    public int Defence;
    [Space]
    public float DamagePrecentBonus;
    public float DamageResistancePrecentBonus;
    [Space]
    public EquipmentType EquipmentType;
}
