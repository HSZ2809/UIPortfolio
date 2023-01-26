using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item_Piece_", menuName = "Item Data/Piece", order = 4)]
public class PieceItemData : StackableItemData
{
    public override Item CreateItem()
    {
        return new PieceItem(this);
    }
}
