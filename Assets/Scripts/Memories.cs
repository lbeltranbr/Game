using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Memories : MonoBehaviour
{
    public string path;
    public Text nameText;
    public Text dialogueText;
    public AudioSource sound;
    public bool changescene;

    private Queue<string> dialog = new Queue<string>();
    private Queue<string> names = new Queue<string>();

    private void Awake()
    {
        StartCoroutine("start");
    }

    public void Create_Lists()
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

    public void DisplayNextSentence()
    {
        if (names.Count == 0)
        {
            if (FindObjectOfType<SimpleMovement>())
                FindObjectOfType<SimpleMovement>().enabled = true;

            gameObject.GetComponent<Animator>().SetTrigger("Out");
            StartCoroutine("end");
            return;
        }
        nameText.text = names.Dequeue();
        string sentence = dialog.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        sound.Play();
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
        sound.Stop();
        yield return new WaitForSeconds(2.0f);
        DisplayNextSentence();

    }
    IEnumerator start()
    {
        yield return new WaitForSeconds(2.0f);

        Create_Lists();

        if (FindObjectOfType<SimpleMovement>())
            FindObjectOfType<SimpleMovement>().enabled = false;

        DisplayNextSentence();
    }

    IEnumerator end()
    {

        yield return new WaitForSeconds(3.0f);
        if (changescene)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Single);
        else
            gameObject.SetActive(false);

    }

}
