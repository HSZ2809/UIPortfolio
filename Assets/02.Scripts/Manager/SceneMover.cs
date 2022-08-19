using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMover : MonoBehaviour
{
    #region Debug Code

    #if UNITY_EDITOR

    public bool debugMode = true;

    #endif

    #endregion  
    
    #region private field

    bool isSceneChangeable = true;

    #endregion

    #region private method

    void Start()
    {
        DontDestroyOnLoad(this);
    }

    #endregion

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
    
    #region private method

    IEnumerator LoadTargetScene(string targetScene)
    {
        #if UNITY_EDITOR
        if(debugMode)
        {
            Debug.Log("SceneManager >> Scene Change : " + targetScene);
        }
        #endif

        yield return new WaitForSeconds(1);

        AsyncOperation async = SceneManager.LoadSceneAsync(targetScene);
        isSceneChangeable = true;

        yield return true;
    }

    #endregion
}