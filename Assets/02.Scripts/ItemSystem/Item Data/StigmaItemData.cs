using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StigmaType
{
    DEFAULT, TOP, MIDDLE, BOTTOM
}

[CreateAssetMenu(fileName = "Item_Stigma_", menuName = "Item Data/Stigma", order = 2)]
public class StigmaItemData : EquipmentItemData
{
    public int          Defence => defence;
    public StigmaType   S_type => s_type;

    [SerializeField] private int          defence = -1;
    [SerializeField] private StigmaType   s_type = StigmaType.DEFAULT;

    public override Item CreateItem()
    {
        return new StigmaItem(this);
    }
}