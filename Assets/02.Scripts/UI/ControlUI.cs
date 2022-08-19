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

    [주의사항]
    - Awake()에 태그가 Player인 gameObject를 찾도록 설계되어 있으나 이는 이후 수정해야 한다.
************************************************************/

public class ControlUI : MonoBehaviour
{
    ///////////////////////////////////////////
    #region 변수 선언

    [Header("Item Slot")]
    [SerializeField] private List<ItemSlotUI> slotList = new List<ItemSlotUI>();

    [Header("Connected Component")]
    [SerializeField] private Inventory inventory;

    private GraphicRaycaster gr;
    private PointerEventData ped;
    private List<RaycastResult> rrList;

    private ItemSlotUI pointerOverSlot;
    private ItemSlotUI beginDragSlot;
    private Transform beginDragIconTransform;

    private Vector3 beginDragIconPoint;
    private Vector3 beginDragCursorPoint;
    private int beginDragSlotSiblingIndex;
            
    #endregion
    ///////////////////////////////////////////

    ///////////////////////////////////////////
    #region private 함수

    private void Awake()
    {
        inventory = GameObject.FindGameObjectWithTag("InventoryManager").GetComponent<Inventory>();

        TryGetComponent(out gr);
        if (gr == null)
            gr = gameObject.AddComponent<GraphicRaycaster>();

        ped = new PointerEventData(EventSystem.current);
        rrList = new List<RaycastResult>(10);

        // playerPos = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // private void Start() 
    // {
    //     SetAccessibleInventorySlotRange();
    // }

    // private void OnEnable() 
    // {
    //     for(int i = 0; i < slotList.Capacity; i++)
    //     {
    //         slotList[i].UpdateSlot();
    //     }
    // }

    private T RaycastAndGetFirstComponent<T>() where T : Component
    {
        rrList.Clear();

        gr.Raycast(ped, rrList);

        if(rrList.Count == 0)
            return null;

        return rrList[0].gameObject.GetComponent<T>();
    }

    // private void OnPointerDown()
    // {
    //     if (Input.GetMouseButtonDown(0))
    //     {
    //         beginDragSlot = RaycastAndGetFirstComponent<ItemSlotUI>();

    //         if (beginDragSlot != null && beginDragSlot.HasItem && beginDragSlot.CanAccessible)
    //         {
    //             beginDragIconTransform = beginDragSlot.IconRect.transform;
    //             beginDragIconPoint = beginDragIconTransform.position;
    //             beginDragCursorPoint = Input.mousePosition;

    //             // UI 가장 위에 올려놓는 코드인데 적절한지 모르겠다
    //             beginDragSlot.transform.parent.transform.parent.transform.SetAsLastSibling();
    //             beginDragSlotSiblingIndex = beginDragSlot.transform.GetSiblingIndex();
    //             beginDragSlot.transform.SetAsLastSibling();
    //         }
    //         else
    //         {
    //             beginDragSlot = null;
    //         }
    //     }
    // }

    // private void OnPointerDrag()
    // {
    //     if(beginDragSlot == null) return;

    //     if (Input.GetMouseButton(0))
    //     {
    //         beginDragIconTransform.position = beginDragIconPoint + (Input.mousePosition - beginDragCursorPoint);
    //     }
    // }

    // private void OnPointerUp()
    // {
    //     if (Input.GetMouseButtonUp(0))
    //     {
    //         // End Drag
    //         if (beginDragSlot != null)
    //         {
    //             // 위치 복원
    //             beginDragIconTransform.position = beginDragIconPoint;

    //             // UI 순서 복원
    //             beginDragSlot.transform.SetSiblingIndex(beginDragSlotSiblingIndex);

    //             // 드래그 완료 처리
    //             EndDrag();

    //             // 참조 제거
    //             beginDragSlot = null;
    //             beginDragIconTransform = null;
    //         }
    //     }
    // }
    
    // private void EndDrag()
    // {
    //     ItemSlotUI endDragSlot = RaycastAndGetFirstComponent<ItemSlotUI>();

    //     if(endDragSlot != null && endDragSlot.CanAccessible)
    //     {
    //         if(TrySwapItem(beginDragSlot, endDragSlot))
    //         {
    //             if(beginDragSlot.ConnectedStorage == playerStatus.Equipments)
    //                 playerStatus.EquipmentChange(beginDragSlot.Index);

    //             if(endDragSlot.ConnectedStorage == playerStatus.Equipments)
    //                 playerStatus.EquipmentChange(endDragSlot.Index);
    //         }
    //     }

    //     if(!IsOverUI())
    //     {
    //         TryDropItem();
    //     }
    // }

    // private bool TrySwapItem(ItemSlotUI start, ItemSlotUI end)
    // {
    //     if(start == end) 
    //         return false;

    //     Item itemA = start.ConnectedStorage.GetItem(start.Index);
    //     Item itemB = end.ConnectedStorage.GetItem(end.Index);

    //     if(!end.CanSwap(itemA)) return false;
    //     if(!start.CanSwap(itemB)) return false;

    //     if(itemA != null && itemB != null 
    //         && itemA.Data == itemB.Data 
    //         && itemA is StackableItem si1 && itemB is StackableItem si2)
    //     {
    //         int maxAmount = si2.MaxAmount;
    //         int sum = si1.Amount + si2.Amount;

    //         if(sum <= maxAmount)
    //         {
    //             si1.SetAmount(0);
    //             si2.SetAmount(sum);
    //         }
    //         else
    //         {
    //             si1.SetAmount(sum - maxAmount);
    //             si2.SetAmount(maxAmount);
    //         }
    //     }
    //     else
    //     {
    //         start.ConnectedStorage.SetItem(itemB, start.Index);
    //         end.ConnectedStorage.SetItem(itemA, end.Index);
    //         // items[index1] = itemB;
    //         // items[index2] = itemA;
    //     }

    //     start.UpdateSlot();
    //     end.UpdateSlot();

    //     return true;
    // }

    // private void TryDropItem()
    // {
    //     DropItem();
    //     beginDragSlot.ConnectedStorage.Remove(beginDragSlot.Index);
    //     beginDragSlot.UpdateSlot();
    // }

    private bool IsOverUI() => EventSystem.current.IsPointerOverGameObject();

    // private void DropItem()
    // {
    //     Item item = beginDragSlot.ConnectedStorage.GetItem(beginDragSlot.Index);
        
    //     if(item.Data.DropItemPrefab != null)
    //     {
    //         DroppedItem droppedItem = (Instantiate(item.Data.DropItemPrefab, playerPos.position, Quaternion.identity)).GetComponent<DroppedItem>();
    //         droppedItem._Item = item;
    //     }
    // }

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

    // public void SetAccessibleInventorySlotRange()
    // {
    //     for(int i = 0; i < slotList.Count; i++)
    //     {
    //         slotList[i].SetSlotState(i < inventory.Capacity);
    //     }
    // }

    // public void SetAccessibleStashSlotRange()
    // {
    //     for(int i = 0; i < InteractSlotList.Count; i++)
    //     {
    //         InteractSlotList[i].SetSlotState(i < stash.Capacity);
    //     }
    // }

    #endregion
    ///////////////////////////////////////////
}
