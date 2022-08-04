using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 변수 미할당 시 출력되는 오류 메시지 출력을 막는 코드
#pragma warning disable 649, CS0067
#pragma warning disable 67, CS0649

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
