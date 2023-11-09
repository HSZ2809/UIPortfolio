using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ZUN
{
    public class ButtonUnloadScene : MonoBehaviour
    {
        [SerializeField] private ZUN.SceneList sceneName = ZUN.SceneList.DEFAULT;
        private ZUN.SceneLoadManager sceneMoveManager = null;
        private DialogControler notion = null;

        private void Awake()
        {
            sceneMoveManager = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<ZUN.SceneLoadManager>();
            notion = GameObject.FindGameObjectWithTag("Notion").GetComponent<DialogControler>();
        }

        // public void UnloadScene()
        // {
        //     if(sceneName == ZUN.SceneList.DEFAULT)
        //     {
        //         notion.ShowDialog("error", "Scene not assigned");
        //         return;
        //     }

        //     SceneManager.UnloadSceneAsync((int)sceneName);
        // }

        public void RequestUnloadScene()
        {
            #if UNITY_EDITOR
            if(sceneName == ZUN.SceneList.DEFAULT)
            {
                Debug.Log("Scene unassigned error");
            }
            #endif

            if(sceneName != ZUN.SceneList.DEFAULT)
                sceneMoveManager.UnloadScene(sceneName);
        }
    }
}