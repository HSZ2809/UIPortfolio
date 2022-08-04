using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StackableItemData : ItemData
{
    public int MaxAmount => maxAmount;
    [SerializeField] private int maxAmount = 50;
}
