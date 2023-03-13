using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour
{
    void Start()
    {
        //SceneManager.LoadScene("OtherSceneName", LoadSceneMode.Additive);
    }

    public void LoadA(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }
}
