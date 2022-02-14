using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateTUT : MonoBehaviour
{
    public GameObject s_key;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        s_key.SetActive(true);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKey(KeyCode.S))
            StartCoroutine("fade");

    }
    IEnumerator fade()
    {
        //s_key.SetActive(false);
        gameObject.GetComponent<Animator>().SetTrigger("Fade");
        s_key.GetComponent<Animator>().SetTrigger("Fade");
        yield return new WaitForSeconds(1f);

    }
}
