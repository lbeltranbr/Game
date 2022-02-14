using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableNPC : MonoBehaviour
{
    public GameObject E_key;
    public GameObject dialogue_canvas;


    private void Update()
    {
        if (E_key.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                FindObjectOfType<DialogueTrigger>().TriggerDialogue();
                dialogue_canvas.SetActive(true);
                E_key.SetActive(false);

            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            E_key.SetActive(true);

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            E_key.SetActive(false);

        }
    }
}
