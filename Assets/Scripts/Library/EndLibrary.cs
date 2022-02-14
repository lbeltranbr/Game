using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
using UnityEngine.UI;
public class EndLibrary : MonoBehaviour
{
    public GameObject cont_button;
    public Text nameText;
    public Text dialogueText;
    public GameObject dialogue_canvas;

    private Queue<string> dialogue = new Queue<string>();
    private Queue<string> names = new Queue<string>();
    // Update is called once per frame
    private void Start()
    {
        dialogue.Enqueue("My memories are still missing but I’m getting close to resolving them!");
        names.Enqueue("Girl");
    }

    public void DisplayNextSentence()
    {
        if (names.Count == 0)
        {
           
            dialogue_canvas.SetActive(false);

            return;
        }
        nameText.text = names.Dequeue();

        string sentence = dialogue.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        gameObject.GetComponent<AudioSource>().Play();
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
        gameObject.GetComponent<AudioSource>().Stop();
        yield return new WaitForSeconds(2.0f);
        DisplayNextSentence();
        FindObjectOfType<SimpleMovement>().enabled = true;
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        FindObjectOfType<SimpleMovement>().enabled = false;
        DisplayNextSentence();
        dialogue_canvas.SetActive(true);
        cont_button.SetActive(false);

    }
}
