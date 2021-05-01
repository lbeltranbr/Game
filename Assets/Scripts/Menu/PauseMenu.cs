using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;



public class PauseMenu : MonoBehaviour
{
    public GameObject pause;
    public GameObject pauseButton;
    public Slider music;
    public Slider sfx;
    public void ActivatePauseMenu()
    {
        pause.SetActive(true);
        pauseButton.SetActive(false);
        //Time.timeScale = 0;
    }

    public void Resume()
    {
        pause.SetActive(false);
        pauseButton.SetActive(true);

        //Time.timeScale = 1;
    }

    public void Retry() 
    { 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);

    }

    public void Save()
    {
        string p = Application.dataPath + "/Text Files/save.txt";
        //List<string> lines = File.ReadAllLines(p).ToList();
        File.WriteAllText(p, SceneManager.GetActiveScene().name);
    }

    public void Options()
    {

    }

    public void Quit()
    {

        SceneManager.LoadScene("InitialScene", LoadSceneMode.Single);
        Time.timeScale = 1;

    }
    public void ChangeVol()
    {
        Utils.ChangeVolume(music.value);
    }
    public void Changesfx()
    {
        Utils.ChangeSFX(sfx.value);
    } 

}
