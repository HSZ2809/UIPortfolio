using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item_Armor_", menuName = "Item Data/Armor", order = 2)]
public class ArmorItemData : EquipmentItemData
{
    public int Defence => defence;

    [SerializeField] private int defence = 1;
    public override Item CreateItem()
    {
        return new ArmorItem(this);
    }
}