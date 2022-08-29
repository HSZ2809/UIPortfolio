using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 변수 미할당 시 출력되는 오류 메시지 출력을 막는 코드
#pragma warning disable 649, CS0067
#pragma warning disable 67, CS0649

/************************************************************
주석 작성일자 : 2022-08-09
작성자 : 홍성준

    [스크립트의 목적]
    - 아이템의 보관, 정렬, 사용을 위한 스크립트

    [필드]
    - 용량(저장고의 크기)
        현재는 인스펙터에서 직접 용량을 입력해주어야 한다
        아이템이 추가될 때마다 동적으로 변화해야 한다
    - 아이템
        Item 형의 클레스를 받을 수 있는 배열이다

    [기능]
    - 아이템 리스트를 보관
    - 아이템 리스트를 정렬
    - 아이템을 사용
************************************************************/

public class Inventory : MonoBehaviour
{
    ///////////////////////////////////////////
    #region 변수 선언

    [SerializeField] private int gold;
    [SerializeField] private int diamond;
    [SerializeField] private int stamina;

    private List<Item> weaponItems = new List<Item>();
    private List<StigmaItem> stigmaItems = new List<StigmaItem>();

    #endregion
    ///////////////////////////////////////////

    ///////////////////////////////////////////
    #region private method

    private void Start()
    {
        DontDestroyOnLoad(this);
    }

    // 수정 필요
    private int FindStackableItemSlot(StackableItemData item, int startIndex = 0)
    {
        for(int i = startIndex; i < weaponItems.Capacity; i++)
        {
            Item searchedItem = weaponItems[i];

            if(searchedItem.Data == item && searchedItem is StackableItem si)
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

    public int AddItem(ItemData itemData, int amount)
    {
        int index;

        if(itemData is StackableItemData siData)
        {
            index = -1;

            index = FindStackableItemSlot(siData, index + 1);

            if(index == -1)
            {
                StackableItem si = siData.CreateItem() as StackableItem;
                si.SetAmount(amount);

                weaponItems.Add(si);

                amount = (amount > siData.MaxAmount) ? (amount - siData.MaxAmount) : 0;
            }
            else
            {
                StackableItem si = weaponItems[index] as StackableItem;
                amount = si.AddAmountAndGetExcess(amount);
            }
        }
        else
        {
            weaponItems.Add(itemData.CreateItem());
            amount = 0;
        }

        return amount;
    }

    public void AddStigmaItem(StigmaItemData itemData)
    {
        stigmaItems.Add(itemData.CreateItem() as StigmaItem);
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

    #endregion
    ///////////////////////////////////////////
}