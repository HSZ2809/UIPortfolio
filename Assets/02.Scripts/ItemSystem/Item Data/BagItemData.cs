using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item_Bag_", menuName = "Item Data/Bag", order = 3)]
public class BagItemData : EquipmentItemData
{
    public int Size => size;

    [SerializeField] private int size = 1;
    public override Item CreateItem()
    {
        return new BagItem(this);
    }
}