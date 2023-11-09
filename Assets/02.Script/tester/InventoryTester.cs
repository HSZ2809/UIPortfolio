using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/************************************************************
주석 작성일자 : 2022-10-26
작성자 : 홍성준

    [스크립트의 목적]
    - 인벤토리의 기능 테스트를 위한 임시 스크립트

    [연결된 오브젝트]
    - 인벤토리(태그로 찾아서 연결)
    - 아이템 데이터들(수동 연결)

    [기능]
    - 인벤토리에 아이템 생성

    [주의사항]
************************************************************/

namespace ZUN
{
    public class InventoryTester : MonoBehaviour
    {
        #region Debug Code

        #if UNITY_EDITOR

        public bool debugMode = true;

        #endif

        #endregion 
        public ZUN.Inventory inventory;

        public WeaponItemData[] WeaponItemDataArray;
        public StigmaItemData[] stigmaItemDataArray;
        public PieceItemData[] pieceItemDataArray;
        public int pieceAmount = 0;
        public ConsumableItemData[] consumableItemDataArray;
        public int consumableItemAmount = 0;

        private void Awake() 
        {
            inventory = GameObject.FindGameObjectWithTag("InventoryManager").GetComponent<ZUN.Inventory>();
        }

        public void SpawnWeaponItem()
        {
            inventory.AddWeaponItem(WeaponItemDataArray[0]);

            #if UNITY_EDITOR
            if(debugMode)
            {
                Debug.Log("Inventory Tester >> Item Added : [Weapon]" + WeaponItemDataArray[0]);
            }
            #endif
        }

        public void SpawnStigmaItem()
        {
            inventory.AddStigmaItem(stigmaItemDataArray[0]);

            #if UNITY_EDITOR
            if(debugMode)
            {
                Debug.Log("Inventory Tester >> Item Added : [Stigma]" + stigmaItemDataArray[0]);
            }
            #endif
        }

        public void SpawnPieceItem()
        {
            inventory.AddPieceItem(pieceItemDataArray[0], pieceAmount);
            inventory.AddPieceItem(pieceItemDataArray[1], pieceAmount + 3);

            #if UNITY_EDITOR
            if(debugMode)
            {
                Debug.Log("Inventory Tester >> Item Added : [Piece]" + pieceItemDataArray[0]);
            }
            #endif
        }

        public void SpawnConsumableItem()
        {
            inventory.AddConsumableItem(consumableItemDataArray[0], consumableItemAmount);
            inventory.AddConsumableItem(consumableItemDataArray[2], consumableItemAmount + 1);

            #if UNITY_EDITOR
            if(debugMode)
            {
                Debug.Log("Inventory Tester >> Item Added : [ConsumableItem]" + consumableItemDataArray[0]);
            }
            #endif
        }
    }
}