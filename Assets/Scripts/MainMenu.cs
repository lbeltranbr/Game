using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using System.Linq;

public class MainMenu : MonoBehaviour
{
    public GameObject anim;
    public GameObject load;
    public Slider music;
    public Slider sfx;
    private void Start()
    {
        string p = Application.dataPath + "/Text Files/save.txt";
        string[] lines = File.ReadAllLines(p).ToArray();
        if (lines.Count() != 0)
            load.SetActive(true);
    }
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
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Single);
    }

    public void ChangeVol()
    {
        Sound.ChangeVolume(music.value);
    }
    public void Changesfx()
    {
        Sound.ChangeSFX(sfx.value);
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
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(lines[0], LoadSceneMode.Single);
    }


}
