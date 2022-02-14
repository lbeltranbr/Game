using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ExecuteDialogue : MonoBehaviour
{
    public GameObject dialogue_canvas;
    public Text nameText;
    public Text dialogueText;

    private Queue<string> dialog = new Queue<string>();
    private Queue<string> names = new Queue<string>();


    public void DisplayNextSentence()
    {
        if (names.Count == 0)
        {
            dialogue_canvas.SetActive(false);
            return;
        }
        nameText.text = names.Dequeue();
        string sentence = dialog.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }
    private IEnumerator TypeSentence(string sentence)
    {
        dialogue_canvas.GetComponent<AudioSource>().Play();
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
        dialogue_canvas.GetComponent<AudioSource>().Stop();

    }
    public void GetDialogueFromFile(string path)
    {
        List<string> lines = File.ReadAllLines(path).ToList();
        int i = 0;
        names.Clear();
        dialog.Clear();

        foreach (string line in lines)
        {
            if (i % 2 == 0)
                names.Enqueue(line);
            else
                dialog.Enqueue(line);
            i++;
        }
    }
}
