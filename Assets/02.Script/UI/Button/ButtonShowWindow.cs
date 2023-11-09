using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ZUN
{
    public class ButtonShowWindow : MonoBehaviour
    {
        [SerializeField] private GameObject window = null;
        private DialogControler notion = null;

        private void Awake() 
        {
            notion = GameObject.FindGameObjectWithTag("Notion").GetComponent<DialogControler>();
        }

        private void Start() 
        {
            GetComponent<Button>().onClick.AddListener(BtnExit);
        }

        private void BtnExit()
        {
            if(window != null)
            {
                window.SetActive(true);
            }
            else
            {
                notion.ShowDialog("error", "Window not found");
            }
        }
    }
}