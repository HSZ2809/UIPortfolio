using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item_Weapon_", menuName = "Item Data/Weaopn", order = 1)]
public class WeaponItemData : EquipmentItemData
{
    public int          Damage => damage;
    public GameObject   WeaponItemPrefab => weaponItemPrefab;

    [SerializeField] private int          damage = -1;
    [SerializeField] private GameObject   weaponItemPrefab = null;

    public override Item CreateItem()
    {
        return new WeaponItem(this);
    }
}