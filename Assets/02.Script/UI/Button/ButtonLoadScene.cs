using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZUN
{
    public class ButtonLoadScene : MonoBehaviour
    {
        // private field
        [SerializeField] private ZUN.SceneList sceneName = ZUN.SceneList.DEFAULT;
        [SerializeField] private UnityEngine.SceneManagement.LoadSceneMode mode;
        private ZUN.SceneLoadManager sceneLoadManager = null;
        private DialogControler notion = null;

        // private method
        private void Awake() 
        {
            sceneLoadManager = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<ZUN.SceneLoadManager>();
            notion = GameObject.FindGameObjectWithTag("Notion").GetComponent<DialogControler>();
        }

        public void RequestLoadScene()
        {
            if(sceneName == ZUN.SceneList.DEFAULT)
            {
                notion.ShowDialog("error", "Scene not assigned");
                return;
            }

            sceneLoadManager.LoadScene(sceneName, mode);
        }
    }
}