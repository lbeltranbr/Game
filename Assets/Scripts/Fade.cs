using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Fade : MonoBehaviour
{
    public GameObject animOut;
    // Start is called before the first frame update
   
    private void Awake()
    {
        StartCoroutine(DeactivateOut());
    }
  
    IEnumerator DeactivateOut()
    {
        yield return new WaitForSeconds(2f);
        animOut.SetActive(false);
    }
}
