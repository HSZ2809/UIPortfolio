using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumableItem : StackableItem, IUsableItem
{
    public ConsumableItem(ConsumableItemData data, int amount = 1) : base(data, amount) { }

    public bool Use()
    {
        Amount--;

        return true;
    }
}
