using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string SceneName;
    public GameObject anim;
    public void GoToMainScene()
    {
        StartCoroutine("loadScene");
    }
    public void Quit()
    {
        Application.Quit();
    }

    IEnumerator loadScene()
    {
        anim.SetActive(true);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneName, LoadSceneMode.Single);

    }
}
