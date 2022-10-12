using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// 변수 미할당 시 출력되는 오류 메시지 출력을 막는 코드
#pragma warning disable 649, CS0067
#pragma warning disable 67, CS0649

public class DialogControler : MonoBehaviour
{
    ///////////////////////////////////////////
    #region Field

    [SerializeField] private GameObject canvas;
    [SerializeField] private Text title;
    [SerializeField] private Text context;
    [SerializeField] private GameObject btnBack;
    [SerializeField] private GameObject[] btnExit = new GameObject[2];
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
