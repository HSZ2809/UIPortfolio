using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.EventSystems;
using UnityEngine.UI;

// 변수 미할당 시 출력되는 오류 메시지 출력을 막는 코드
#pragma warning disable 649, CS0067
#pragma warning disable 67, CS0649

/************************************************************
주석 작성일자 : 2022-08-19
작성자 : 홍성준

    [스크립트의 목적]
    - 인벤토리 UI를 컨트롤하는 컴포넌트다

    [연결된 오브젝트]
    - 아이템 슬롯(임시로 수동 연결)
    - 인벤토리(태그로 찾아서 연결)

    [주의사항]
************************************************************/

public class UIControler : MonoBehaviour
{
    ///////////////////////////////////////////
    #region 변수 선언

    [Header("Item Slot")]
    [SerializeField] private List<ItemSlotUI> slotList = new List<ItemSlotUI>();

    [Header("Connected Component")]
    [SerializeField] private Inventory inventory;
    [SerializeField] private GameObject itmeSlotUIPref;

    public Inventory _Inventory { get{ return inventory; } }
            
    #endregion
    ///////////////////////////////////////////

    ///////////////////////////////////////////
    #region private 함수

    private void Awake()
    {
        inventory = GameObject.FindGameObjectWithTag("InventoryManager").GetComponent<Inventory>();
    }

    private void Start()
    {
        int inventoryCount = inventory.GetInventoryCount();
        slotList.Capacity = inventoryCount;

        for(int i = 1; i <= inventoryCount; i++)
        {
            GameObject itmeSlot = Instantiate(itmeSlotUIPref, this.transform.GetChild(0).GetChild(0).GetChild(0));
            itmeSlot.GetComponent<ItemSlotUI>().SetSlotIndex(i - 1);
            itmeSlot.gameObject.name = $"ItemSlot [{i - 1}]";

            slotList.Add(itmeSlot.GetComponent<ItemSlotUI>());
        }
    }

    #endregion
    ///////////////////////////////////////////

    ///////////////////////////////////////////
    #region public 함수

    // 밑의 세 함수는 기존의 아이템 변경 방식을 위해 있는 함수이다.
    // 필요시에는 식제할 수도 있다.
    public void SetItemIcon(int index, Sprite icon)
    {
        slotList[index].SetItem(icon);
    }

    public void SetItemAmountText(int index, int amount)
    {
        slotList[index].SetItemAmount(amount);
    }

    public void RemoveItem(int index)
    {
        slotList[index].RemoveItem();
    }

    public void RefreshAllSlot() 
    {
        for(int i = 0; i < slotList.Capacity; i++)
        {
            slotList[i].UpdateSlot();
        }
    }

    #endregion
    ///////////////////////////////////////////
}
