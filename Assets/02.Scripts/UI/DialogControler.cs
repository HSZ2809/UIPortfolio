using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ZUN
{
    public class DialogControler : MonoBehaviour
    {
        ///////////////////////////////////////////
        #region Field

        [SerializeField] private GameObject canvas = null;
        [SerializeField] private Text title = null;
        [SerializeField] private Text context = null;
        [SerializeField] private GameObject btnBack = null;
        [SerializeField] private GameObject[] btnExit = new GameObject[3];
        // [SerializeField] private GameObject btnConfirm;

        public Button testbtn;

        #endregion
        ///////////////////////////////////////////

        ///////////////////////////////////////////
        #region private method
        void Start()
        {
            DontDestroyOnLoad(this);

            for(int i = 0; i < btnExit.Length; i++)
            {
                btnExit[i].GetComponent<Button>().onClick.AddListener(BtnExit);
            }
        }

        // void Update() 
        // {
        //     if(Input.GetMouseButtonDown(0))
        //     {
        //         if(!EventSystem.current.IsPointerOverGameObject())
        //         {
        //             BtnExit();
        //         }
        //     }
        // }

        void BtnExit()
        {
            canvas.SetActive(false);

            title.text = "error";
            context.text = "error context non-transmission error";
        }

        #endregion
        ///////////////////////////////////////////

        ///////////////////////////////////////////
        #region public method

        public void ShowDialog(string _title, string _context)
        {
            title.text = _title;
            context.text = _context;

            canvas.SetActive(true);
        }

        #endregion
        ///////////////////////////////////////////
    }
}