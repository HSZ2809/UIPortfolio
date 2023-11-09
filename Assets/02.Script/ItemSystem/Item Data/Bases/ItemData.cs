using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class ItemData : ScriptableObject
{
    [SerializeField] private int      id = -1;
    [SerializeField] private string   itemName = null;
    [Multiline]
    [SerializeField] private string   tooltip = null;
    [SerializeField] private Sprite   iconSprite = null;

    public int      ID => id;
    public string   Name => itemName;
    public string   Tooltip => tooltip;
    public Sprite   IconSprite => iconSprite;

    public abstract Item CreateItem();
}
