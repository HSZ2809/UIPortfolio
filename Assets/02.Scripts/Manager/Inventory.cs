using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/************************************************************
주석 작성일자 : 2022-10-26
작성자 : 홍성준

    [스크립트의 목적]
    - 아이템의 보관, 정보 제공, 사용을 위한 스크립트

    [기능]
    - 아이템 리스트를 보관
    - 저장된 아이템의 정보 제공
    - 소모성 아이템을 사용했을 때 갯수 변화

    [주의사항]
************************************************************/
namespace ZUN
{
    public class Inventory : MonoBehaviour
    {
        ///////////////////////////////////////////
        #region private field

        [SerializeField] private int gold = -1;
        [SerializeField] private int diamond = -1;
        [SerializeField] private int stamina = -1;

        private List<Item>           weaponItems = new List<Item>();
        private List<StigmaItem>     stigmaItems = new List<StigmaItem>();
        private List<PieceItem>      pieceItems = new List<PieceItem>();
        private List<ConsumableItem> consumableItems = new List<ConsumableItem>();

        #endregion
        ///////////////////////////////////////////

        ///////////////////////////////////////////
        #region private method

        private void Start()
        {
            DontDestroyOnLoad(this);
        }

        private int FindPieceItem(PieceItemData item, int startIndex = 0)
        {
            for(int i = startIndex; i < pieceItems.Capacity; i++)
            {
                if(pieceItems[i].Data == item)
                {
                    return i;
                }
            }

            return -1;
        }

        private int FindConsumableItem(ConsumableItemData item, int startIndex = 0)
        {
            for(int i = startIndex; i < consumableItems.Capacity; i++)
            {
                if(consumableItems[i].Data == item)
                {
                    return i;
                }
            }

            return -1;
        }

        #endregion
        ///////////////////////////////////////////

        ///////////////////////////////////////////
        #region public method

        public void AddWeaponItem(WeaponItemData itemData)
        {

            weaponItems.Add(itemData.CreateItem() as WeaponItem);
        }

        public void AddStigmaItem(StigmaItemData itemData)
        {
            stigmaItems.Add(itemData.CreateItem() as StigmaItem);
        }

        public void AddPieceItem(PieceItemData itemData)
        {
            pieceItems.Add(itemData.CreateItem() as PieceItem);
        }

        public void AddConsumableItem(ConsumableItemData itemData)
        {
            consumableItems.Add(itemData.CreateItem() as ConsumableItem);
        }

        public Item GetItem(int index, SlotType st)
        {
            switch(st)
            {
                case SlotType.WEAPON :
                if (weaponItems.Capacity < index + 1) return null;
                return weaponItems[index];

                case SlotType.STIGMA :
                if (stigmaItems.Capacity < index + 1) return null;
                return stigmaItems[index];

                case SlotType.PIECE :
                if (pieceItems.Capacity < index + 1) return null;
                return pieceItems[index];

                case SlotType.CONSUMABLEITEM :
                if (consumableItems.Capacity < index + 1) return null;
                return consumableItems[index];

                default :
                return null;
            }
        }

        public int GetWeaponCount()
        {
            return weaponItems.Count;
        }

        public int GetStigmaCount()
        {
            return stigmaItems.Count;
        }

        public int GetPieceCount()
        {
            return pieceItems.Count;
        }

        public int GetConsumableItemCount()
        {
            return consumableItems.Count;
        }

        #endregion
        ///////////////////////////////////////////

        // 수량이 있는 아이템을 추가하는 로직. 수정 필요.
        // public int AddItem(ItemData itemData, int amount)
        // {
        //     int index;

        //     if(itemData is StackableItemData siData)
        //     {
        //         index = -1;

        //         index = FindStackableItemSlot(siData, index + 1);

        //         if(index == -1)
        //         {
        //             StackableItem si = siData.CreateItem() as StackableItem;
        //             si.SetAmount(amount);

        //             weaponItems.Add(si);

        //             amount = (amount > siData.MaxAmount) ? (amount - siData.MaxAmount) : 0;
        //         }
        //         else
        //         {
        //             StackableItem si = weaponItems[index] as StackableItem;
        //             amount = si.AddAmountAndGetExcess(amount);
        //         }
        //     }
        //     else
        //     {
        //         weaponItems.Add(itemData.CreateItem());
        //         amount = 0;
        //     }

        //     return amount;
        // }
    }
}