using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 변수 미할당 시 출력되는 오류 메시지 출력을 막는 코드
#pragma warning disable 649, CS0067
#pragma warning disable 67, CS0649

[CreateAssetMenu(fileName = "Item_Material_", menuName = "Item Data/Material", order = 4)]
public class PieceItemData : StackableItemData
{
    public override Item CreateItem()
    {
        return new PieceItem(this);
    }
}
