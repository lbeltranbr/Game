using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToNextLevel : MonoBehaviour
{
    public GameObject animIn;
    public string levelName;
    IEnumerator ActivateIn()
    {
        animIn.SetActive(true);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(levelName, LoadSceneMode.Single);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
            StartCoroutine(ActivateIn());
    }
}
