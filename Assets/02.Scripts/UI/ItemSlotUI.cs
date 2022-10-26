using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

// 변수 미할당 시 출력되는 오류 메시지 출력을 막는 코드
#pragma warning disable 649, CS0067
#pragma warning disable 67, CS0649

/************************************************************
주석 작성일자 : 2022-02-17
작성자 : 홍성준

    [스크립트의 목적]
    - 저장소에 저장된 아이템의 상태를 반영

    [연결된 오브젝트]
    - 아이템의 이미지
    - 아이템의 갯수를 반영하는 텍스트
    - UIControler
    - 로직에 필요한 것들

    [필드]
    - (수동입력)인덱스
    - 로직에 필요한 것들

    [기능]
    - 해당되는 저장소의 변경이 있을 때 그 결과를 반영
************************************************************/

public enum SlotType { WEAPON, STIGMA, PIECE, CONSUMABLEITEM }

public class ItemSlotUI : MonoBehaviour
{
    ///////////////////////////////////////////
    #region Field

    [SerializeField] private Image icon;
    [SerializeField] private Text amountText;
    // private RectTransform iconRect;
    // private RectTransform slotRect;
    private Image slotImage;
    
    [SerializeField] private int index;

    [Space]
    [SerializeField] private UIControler uiControler;
    [SerializeField] private SlotType slotType;

    private bool canAccessibleSlot = true;
    private bool canAccessibleItem = true;

    public int Index { get{ return index; } }
    // public bool HasItem { get{ return icon.sprite != null; } }
    public bool CanAccessible { get{ return canAccessibleSlot && canAccessibleItem; } }

    // public RectTransform IconRect { get{ return iconRect;} }
    // public RectTransform SlotRect { get{ return slotRect;} }

    public readonly Color cannotAccessibleSlotColor = new Color(0.0f, 0.0f, 0.0f, 0.0f);

    #endregion
    ///////////////////////////////////////////

    ///////////////////////////////////////////
    #region private method

    private void Awake() 
    {
        icon = transform.GetChild(0).GetComponent<Image>();
        amountText = transform.GetChild(0).GetChild(0).GetComponent<Text>();
        slotImage = GetComponent<Image>();
        // slotRect = GetComponent<RectTransform>();
        // iconRect = icon.rectTransform;
        uiControler = GameObject.FindGameObjectWithTag("UIControler").GetComponent<UIControler>();
        // inventory = GameObject.FindGameObjectWithTag("InventoryManager").GetComponent<Inventory>();

        icon.raycastTarget = false;
        amountText.raycastTarget = false;
    }

    private void Start() 
    {
        UpdateSlot();
    }

    private void ShowIcon() => icon.gameObject.SetActive(true); 
    private void HideIcon() => icon.gameObject.SetActive(false); 
    private void ShowText() => amountText.gameObject.SetActive(true); 
    private void HideText() => amountText.gameObject.SetActive(false);

    #endregion
    ///////////////////////////////////////////

    ///////////////////////////////////////////
    #region public method

    public void SetSlotIndex(int _index) => index = _index;

    public void SetSlotType(SlotType st) => slotType = st;

    public void SetSlotState(bool check)
    {
        if(canAccessibleSlot == check) return;

        if(check)
        {
            slotImage.color = Color.black;
        }
        else
        {
            slotImage.color = cannotAccessibleSlotColor;
            HideIcon();
            HideText();
        }

        canAccessibleSlot = check;
    }

    public void SetItem(Sprite itemSprite)
    {
        if (itemSprite != null)
        {
            icon.sprite = itemSprite;
            ShowIcon();
        }
        else
        {
            RemoveItem();
        }
    }

    public void RemoveItem()
    {
        icon.sprite = null;
        HideIcon();
        HideText();
    }

    public void SetItemAmount(int amount)
    {
        if(amount > 1)
            ShowText();
        else
            HideText();

        amountText.text = amount.ToString();
    }

    // public bool CanSwap(Item item)
    // {
    //     if(item == null) return true; 
    //     if(SlotType == ItemType.DEFAULT) return true;
    //     if(item.Data.IType == SlotType) return true;

    //     return false;
    // }

    public void UpdateSlot()
    {
        Item item = uiControler._Inventory.GetItem(Index, slotType);

        if (item != null)
        {
            SetItem(item.Data.IconSprite);

            if (item is StackableItem si)
            {
                if (si.IsEmpty)
                {
                    RemoveIcon();
                    return;
                }
                else
                {
                    SetItemAmount(si.Amount);
                }
            }
            else
            {
                SetItemAmount(1);
            }
        }
        else
        {
            RemoveIcon();
        }

        void RemoveIcon()
        {
            RemoveItem();
            SetItemAmount(1);
        }
    }
    
    #endregion
    ///////////////////////////////////////////
}
