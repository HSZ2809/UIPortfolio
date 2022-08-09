using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMover : MonoBehaviour
{
    // private field
    bool isSceneChangeable = true; 

    // private method
    void Start()
    {
        DontDestroyOnLoad(this);
    }

    // public method
    public void LoadScene(string targetScene)
    {
        if(isSceneChangeable)
        {
            isSceneChangeable = false;
            StartCoroutine(LoadTargetScene(targetScene));
        }

    }
    
    IEnumerator LoadTargetScene(string targetScene)
    {
        Debug.Log("Scene Change");

        yield return new WaitForSeconds(1);

        AsyncOperation async = SceneManager.LoadSceneAsync(targetScene);
        isSceneChangeable = true;

        yield return true;
    }
}