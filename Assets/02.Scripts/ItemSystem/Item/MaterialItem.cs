using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialItem : StackableItem
{
    public MaterialItem(MaterialItemData data, int amount = 1) : base(data, amount) { }

    protected override StackableItem Clone(int amount)
    {
        return new MaterialItem(StackableData as MaterialItemData, amount);
    }
}
