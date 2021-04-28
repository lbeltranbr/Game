using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Input_Answer : MonoBehaviour
{
    public GameObject E_key;
    public GameObject Choice;

    // Update is called once per frame
    void Update()
    {
        if(gameObject.GetComponent<Input_Answer>().enabled)
            if (E_key.activeSelf)
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Choice.SetActive(true);
                    E_key.SetActive(false);
                }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (!talk)
        if(gameObject.GetComponent<Input_Answer>().enabled)
            E_key.SetActive(true);

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (gameObject.GetComponent<Input_Answer>().enabled)
            E_key.SetActive(false);

    }
}
