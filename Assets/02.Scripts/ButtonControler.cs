using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonControler : MonoBehaviour
{
    // private field
    [SerializeField] private string sceneName;
    private SceneMover sceneMover = null;

    public string SceneName
    {
        get { return sceneName; }
    }

    // private method
    private void Start() 
    {
        sceneMover = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<SceneMover>();
    }

    public void RequestLoadScene()
    {
        sceneMover.LoadScene(sceneName);
    }
}
