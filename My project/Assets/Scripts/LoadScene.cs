using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour
{
    public Animator transitionAnim;
    public string sceneName;
    
    public void LoadA(string scenename)
    {
        StartCoroutine(LoadSceneCo());
    }

    IEnumerator LoadSceneCo()
    {
        //transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(sceneName);
    }
}
