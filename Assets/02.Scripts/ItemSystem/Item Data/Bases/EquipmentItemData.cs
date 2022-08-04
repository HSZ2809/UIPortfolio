using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EquipmentItemData : ItemData
{
    public int MaxDurability => maxDurability;
    // public ItemType EquipType => equipType;

    [SerializeField] private int maxDurability = 100;
    // [SerializeField] private ItemType equipType;
}
