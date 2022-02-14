using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using System.Linq;

public class ChangeScene : MonoBehaviour
{
    public string SceneName;
    public GameObject anim;
    public Slider music;
    public Slider sfx;
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

    public void ChangeVol()
    {
        Utils.ChangeVolume(music.value);
    }
    public void Changesfx()
    {
        Utils.ChangeSFX(sfx.value);
    }

  
    public void LoadFromFile()
    {

        StartCoroutine("loadSceneFromFile");

    }
    IEnumerator loadSceneFromFile()
    {
        string p = Application.dataPath + "/Text Files/save.txt";
        string[] lines = File.ReadAllLines(p).ToArray();
        anim.SetActive(true);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(lines[0], LoadSceneMode.Single);


    }


}
