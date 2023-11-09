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

        private List<WeaponItem>     weaponItems = new List<WeaponItem>();
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

        public int AddPieceItem(PieceItemData itemData, int amount)
        {
            for(int i = 0; i < pieceItems.Count; i++)
            {
                if(pieceItems[i].Data == itemData)
                {
                    return pieceItems[i].AddAmountAndGetExcess(amount);
                }
            }

            pieceItems.Add(itemData.CreateItem() as PieceItem);
            return pieceItems[pieceItems.Count - 1].AddAmountAndGetExcess(amount);
        }

        public int AddConsumableItem(ConsumableItemData itemData, int amount)
        {
            for(int i = 0; i < consumableItems.Count; i++)
            {
                if(consumableItems[i].Data == itemData)
                {
                    return consumableItems[i].AddAmountAndGetExcess(amount);
                }
            }

            consumableItems.Add(itemData.CreateItem() as ConsumableItem);
            return consumableItems[consumableItems.Count - 1].AddAmountAndGetExcess(amount);
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
    }
}