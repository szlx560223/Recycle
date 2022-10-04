using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManage : MonoBehaviour
{
    public string sceneToChange = "Level01";
    public void ChangeScene()
    {
        SceneManager.LoadScene(sceneToChange);
    }
}
