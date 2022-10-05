using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManage : MonoBehaviour
{
    public string sceneToChange = "Level01";
    public void ChangeScene()
    {
        SceneManager.LoadScene(sceneToChange);
    }
    public void ExitGame()
    {
        #if UNITY_EDITOR    //在编辑器模式下
            EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
