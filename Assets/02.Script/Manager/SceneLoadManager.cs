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
namespace ZUN
{
    public enum SceneList
    {
        DEFAULT = -1,
        Start,
        Lobby,
        Inventory,
        Info_Weapon,
        Info_stigma
    }

    public class SceneLoadManager : MonoBehaviour
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

        IEnumerator LoadTargetScene(ZUN.SceneList targetScene, LoadSceneMode mode)
        {
            #if UNITY_EDITOR
            if(debugMode)
            {
                Debug.Log("SceneManager >> Scene Loaded : " + targetScene + ", LoadSceneMode : " + mode);
            }
            #endif

            // yield return new WaitForSeconds(0.1f);
            

            AsyncOperation async = SceneManager.LoadSceneAsync((int)targetScene, mode);
            isSceneChangeable = true;

            yield return true;
        }

        #endregion
        ///////////////////////////////////////////

        ///////////////////////////////////////////
        #region public method

        public void LoadScene(ZUN.SceneList targetScene, LoadSceneMode mode)
        {
            if(isSceneChangeable)
            {
                isSceneChangeable = false;
                StartCoroutine(LoadTargetScene(targetScene, mode));
            }
        }

        public void UnloadScene(ZUN.SceneList targetScene)
        {
            #if UNITY_EDITOR
            if(debugMode)
            {
                Debug.Log("SceneManager >> Scene Unloaded : " + targetScene);
            }
            #endif

            SceneManager.UnloadSceneAsync((int)targetScene);
        }

        public void LoadItemInfoScene(Item item, ZUN.SlotType itemType)
        {
            StartCoroutine(LoadTargetScene(ZUN.SceneList.Info_Weapon, LoadSceneMode.Additive));

            // while(isSceneChangeable)
            // {
            //     // 대기를 어떻게 해야 하는가?
            //     int i  = 0;
            //     i++;
            //     if(i > 1000)
            //         break;
            // }

            // WeaponInfoViewer WIV = null;
            // while(WIV == null)
            // {
            //     WIV = GameObject.FindObjectOfType<WeaponInfoViewer>();
            // }
            // WIV.item = item;
        }

        #endregion
        ///////////////////////////////////////////
    }
}