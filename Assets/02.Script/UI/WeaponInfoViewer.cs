using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 이 스크립트를 가진 게임 오브젝트는 'WeaponInfoViewer' 라는 테그를 가져야 합니다.
namespace ZUN
{
    public class WeaponInfoViewer : MonoBehaviour
    {
        public WeaponItem item = null;
        public Image weaponImage = null;

        public ZUN.ItemBuffer itemBuffer = null;

        private void Awake() 
        {
            itemBuffer = GameObject.FindObjectOfType<ZUN.ItemBuffer>();
            item = itemBuffer.WI;
            weaponImage.sprite = item.Data.IconSprite;
        }

        private void Start() 
        {
            
        }
    }
}
