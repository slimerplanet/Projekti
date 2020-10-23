﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Food Object", menuName = "Inventory System/Items/Food Object")]

public class DefaultItem : ItemObject
{
    public int restoreHealthValue;
    public void Awake()
    {
        type = ItemType.Food;
    }
}