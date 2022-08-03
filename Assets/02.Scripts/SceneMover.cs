using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMover : MonoBehaviour
{
    // private method
    void Start()
    {
        DontDestroyOnLoad(this);
    }

    // public method
    public void LoadScene(string targetScene)
    {
        StartCoroutine(LoadTargetScene(targetScene));
    }
    
    IEnumerator LoadTargetScene(string targetScene)
    {
        Debug.Log("Scene Change");

        yield return new WaitForSeconds(1);

        AsyncOperation async = SceneManager.LoadSceneAsync(targetScene);

        yield return true;
    }
}