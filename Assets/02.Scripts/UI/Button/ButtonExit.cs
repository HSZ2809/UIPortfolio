using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 변수 미할당 시 출력되는 오류 메시지 출력을 막는 코드
#pragma warning disable 649, CS0067
#pragma warning disable 67, CS0649

public class ButtonExit : MonoBehaviour
{
    private void Start() 
    {
        GetComponent<Button>().onClick.AddListener(BtnExit);
    }

    private void BtnExit()
    {
        gameObject.transform.parent.gameObject.SetActive(false);
    }
}
