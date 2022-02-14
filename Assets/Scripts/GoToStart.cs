using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToStart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("GoStart");
    }

    IEnumerator GoStart()
    {
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene(0, LoadSceneMode.Single);

    }


}
