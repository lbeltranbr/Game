using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class PauseMenu : MonoBehaviour
{
    public Slider music;
    public Slider sfx;
    private void Start()
    {
        music.value = Sound.volume;
        sfx.value = Sound.SFX;
    }
    public void Retry()
    {
        Cave.ResetCheckPoints();
        Tutorial.Reset();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
    }
    public void Save()
    {
        string p = Application.dataPath + "/Text Files/save.txt";
        //List<string> lines = File.ReadAllLines(p).ToList();
        File.WriteAllText(p, SceneManager.GetActiveScene().name);
    }
    public void Quit()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
    public void ChangeVol()
    {
        Sound.ChangeVolume(music.value);
    }
    public void Changesfx()
    {
        Sound.ChangeSFX(sfx.value);
    }

}
