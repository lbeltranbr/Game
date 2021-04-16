using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
using UnityEngine.UI;

public class EnterCave_dialogue : MonoBehaviour
{
    private Queue<string> dialog = new Queue<string>();
    private Queue<string> names = new Queue<string>();
    private bool talk = false;

    public GameObject dialogue_canvas;
    public GameObject cont_button;
    public Text nameText;
    public Text dialogueText;
    public GameObject E_key;
    public string path;
    public int NPC_number;

    // Update is called once per frame
    void Update()
    {
        if (E_key.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Create_Lists();

                dialogue_canvas.SetActive(true);
                E_key.SetActive(false);
                DisplayNextSentence();
                talk = true;
                Utils.activate(NPC_number);
            }
        }
    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(1.0f);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!talk)
            E_key.SetActive(true);

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        E_key.SetActive(false);

    }

    public void DisplayNextSentence()
    {
        if (names.Count == 0)
        {
            dialogue_canvas.SetActive(false);
            talk = false;
            return;
        }
        nameText.text = names.Dequeue();

        string sentence = dialog.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        cont_button.GetComponent<AudioSource>().Play();
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
        cont_button.GetComponent<AudioSource>().Stop();

    }
    private void Create_Lists()
    {
        string p = Application.dataPath + "/Text Files/" + path + ".txt";
        List<string> lines = File.ReadAllLines(p).ToList();
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
