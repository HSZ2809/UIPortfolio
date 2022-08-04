using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 변수 미할당 시 출력되는 오류 메시지 출력을 막는 코드
#pragma warning disable 649, CS0067
#pragma warning disable 67, CS0649

[CreateAssetMenu(fileName = "Item_Weapon_", menuName = "Item Data/Weaopn", order = 1)]
public class WeaponItemData : EquipmentItemData
{
    public int Damage => damage;
    public GameObject WeaponItemPrefab => weaponItemPrefab;

    [SerializeField] private int damage = 1;
    [SerializeField] private GameObject weaponItemPrefab;

    public override Item CreateItem()
    {
        return new WeaponItem(this);
    }
}