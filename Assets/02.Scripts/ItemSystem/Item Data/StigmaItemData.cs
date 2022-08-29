using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 변수 미할당 시 출력되는 오류 메시지 출력을 막는 코드
#pragma warning disable 649, CS0067
#pragma warning disable 67, CS0649

public enum StigmaType
{
    Top, Middle, Bottom
}

[CreateAssetMenu(fileName = "Item_Stigma_", menuName = "Item Data/Stigma", order = 2)]
public class StigmaItemData : EquipmentItemData
{
    public int Defence => defence;
    public StigmaType S_type => s_type;

    [SerializeField] private int defence = 1;
    [SerializeField] private StigmaType s_type;

    public override Item CreateItem()
    {
        return new StigmaItem(this);
    }
}