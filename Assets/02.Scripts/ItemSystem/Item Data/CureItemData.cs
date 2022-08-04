using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 변수 미할당 시 출력되는 오류 메시지 출력을 막는 코드
#pragma warning disable 649, CS0067
#pragma warning disable 67, CS0649

public enum CureNameList
{
    bandage,
    healthkit
}

[CreateAssetMenu(fileName = "Item_Cure_", menuName = "Item Data/Cure", order = 4)]
public class CureItemData : StackableItemData
{
    public CureNameList CureList => cureList;
    [SerializeField] private CureNameList cureList;
    public float Value => value;
    [SerializeField] private float value;
    public override Item CreateItem()
    {
        return new CureItem(this);
    }
}