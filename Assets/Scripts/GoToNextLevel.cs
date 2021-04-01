using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToNextLevel : MonoBehaviour
{
    public string SceneName;

    void OnTriggerEnter2D(Collider2D col)
    {
        SceneManager.LoadScene(SceneName, LoadSceneMode.Single);
    }
}
