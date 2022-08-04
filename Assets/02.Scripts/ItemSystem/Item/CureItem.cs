using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CureItem : StackableItem, IUsableItem
{
    public CureItem(CureItemData data, int amount = 1) : base(data, amount) { }

    public bool Use()
    {
        Amount--;

        return true;
    }

    protected override StackableItem Clone(int amount)
    {
        return new CureItem(StackableData as CureItemData, amount);
    }
}