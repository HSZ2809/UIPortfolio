using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 변수 미할당 시 출력되는 오류 메시지 출력을 막는 코드
#pragma warning disable 649, CS0067
#pragma warning disable 67, CS0649

[CreateAssetMenu(fileName = "Item_ConsumableItem_", menuName = "Item Data/ConsumableItem", order = 4)]
public class ConsumableItemData : StackableItemData
{
    public float Value => value;
    [SerializeField] private float value;
    public override Item CreateItem()
    {
        return new ConsumableItem(this);
    }
}