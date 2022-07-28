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
    public void StartScene()
    {
        StartCoroutine("LoadScene");
    }
    
    IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(3);

        AsyncOperation async = SceneManager.LoadSceneAsync("Lobby");

        yield return true;
    }
}