using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 변수 미할당 시 출력되는 오류 메시지 출력을 막는 코드
#pragma warning disable 649, CS0067
#pragma warning disable 67, CS0649

public abstract class ItemData : ScriptableObject
{
    [SerializeField] private int      id;
    [SerializeField] private string   itemName;
    // [SerializeField] private ItemType iType;
    [Multiline]
    [SerializeField] private string   tooltip;
    [SerializeField] private Sprite   iconSprite;
    // [SerializeField] private GameObject dropItemPrefab;

    public int ID => id;
    public string Name => itemName;
    // public ItemType IType => iType;
    public string Tooltip => tooltip;
    public Sprite IconSprite => iconSprite;
    // public GameObject DropItemPrefab => dropItemPrefab;

    public abstract Item CreateItem();
}
