﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/************************************************************
주석 작성일자 : 2022-02-17
작성자 : 홍성준

    [스크립트의 목적]
    - 인벤토리의 기능 테스트를 위한 임시 스크립트

    [연결된 오브젝트]
    - (수동 연결)인벤토리
    - (수동 연결)아이템 데이터들

    [기능]
    - 인벤토리에 아이템 생성
************************************************************/

public class InventoryTester : MonoBehaviour
{
    #region Debug Code

    #if UNITY_EDITOR

    public bool debugMode = true;

    #endif

    #endregion 
    public Inventory inventory;

    public ItemData[] itemDataArray;
    public StigmaItemData[] stigmaItemArray;

    private void Awake() 
    {
        inventory = GameObject.FindGameObjectWithTag("InventoryManager").GetComponent<Inventory>();
    }

    public void ItemTest()
    {
        inventory.AddItem(itemDataArray[0], 1);

        #if UNITY_EDITOR
        if(debugMode)
        {
            Debug.Log("Inventory Tester >> Item Added : " + itemDataArray[0]);
        }
        #endif
    }

    public void SpawnStigmaItem()
    {
        inventory.AddStigmaItem(stigmaItemArray[0]);

        #if UNITY_EDITOR
        if(debugMode)
        {
            Debug.Log("Inventory Tester >> Item Added : [Stigma]" + stigmaItemArray[0]);
        }
        #endif
    }
}