using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/************************************************************
주석 작성일자 : 2022-10-26
작성자 : 홍성준

    [스크립트의 목적]
    - 씬 이동을 컨트롤하는 컴포넌트다

    [주의사항]
    - 게임 내에 하나만 있어야 한다.
************************************************************/

public class SceneMover : MonoBehaviour
{
    ///////////////////////////////////////////
    #region Debug Code

    #if UNITY_EDITOR

    public bool debugMode = true;

    #endif

    #endregion  
    ///////////////////////////////////////////

    ///////////////////////////////////////////
    #region private field

    bool isSceneChangeable = true;

    #endregion
    ///////////////////////////////////////////

    ///////////////////////////////////////////
    #region private method

    void Start()
    {
        DontDestroyOnLoad(this);
    }

    #endregion
    ///////////////////////////////////////////

    ///////////////////////////////////////////
    #region public method

    public void LoadScene(string targetScene)
    {
        if(isSceneChangeable)
        {
            isSceneChangeable = false;
            StartCoroutine(LoadTargetScene(targetScene));
        }
    }

    #endregion
    
    ///////////////////////////////////////////
    #region private method

    IEnumerator LoadTargetScene(string targetScene)
    {
        #if UNITY_EDITOR
        if(debugMode)
        {
            Debug.Log("SceneManager >> Scene Change : " + targetScene);
        }
        #endif

        yield return new WaitForSeconds((float)0.1);

        AsyncOperation async = SceneManager.LoadSceneAsync(targetScene);
        isSceneChangeable = true;

        yield return true;
    }

    #endregion
    ///////////////////////////////////////////
}