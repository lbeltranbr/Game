using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    public GameObject menu;
    public GameObject menu2;

    private void Awake()
    {
        string p = Application.dataPath + "/Text Files/save.txt";
        string[] lines = File.ReadAllLines(p).ToArray();
        if (lines.Length == 1)
            menu2.SetActive(true);
        else
            menu.SetActive(true);

    }
   
}
