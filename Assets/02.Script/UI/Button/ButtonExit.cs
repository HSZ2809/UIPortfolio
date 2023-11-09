using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ZUN
{
    public class ButtonExit : MonoBehaviour
    {
        [SerializeField] private GameObject window = null;

        private void Start() 
        {
            GetComponent<Button>().onClick.AddListener(BtnExit);
        }

        private void BtnExit()
        {
            window.SetActive(false);
        }
    }
}