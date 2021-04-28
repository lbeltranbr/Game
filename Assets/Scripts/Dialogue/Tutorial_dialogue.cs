using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
using UnityEngine.UI;


public class Tutorial_dialogue : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject dialogue_canvas;
    public Transform npc;
    public Text nameText;
    public Text dialogueText;
    public Text keys;
    public GameObject popup;
    public Animator animation;
    public GameObject cont_button;
    public GameObject cont_button_next;
    



    private bool start;
    private Queue<string> dialog=new Queue<string>();
    private Queue<string> names= new Queue<string>();
    void Start()
    {
        start = true;
        string path = Application.dataPath + "/Text Files/" + "tutorial.txt";
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

    // Update is called once per frame
    void Update()
    {

        if (start)
        {
            StartCoroutine("wait");
            start = false;
           
        }

        if (names.Count() == 6)
        {
            dialogue_canvas.SetActive(false);
            FindObjectOfType<SimpleMovement>().enabled = true;
            keys.gameObject.SetActive(true);
           
            if (npc.position.x < 25)
            {
                Vector3 horizontal = new Vector3(1.0f, 0.0f, 0.0f);
                npc.position = npc.position + horizontal * Time.deltaTime * 6;
                
            }

        }

        if (names.Count() == 3)
        {
            dialogue_canvas.SetActive(false);
            if (popup.activeSelf)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    FindObjectOfType<SimpleMovement>().enabled = false;

                    dialogue_canvas.SetActive(true);
                    DisplayNextSentence();
                    popup.SetActive(false);
                }
            }
           

        }

    }

    public void DisplayNextSentence()
    {
        if (names.Count == 0)
        {
            animation.SetTrigger("Fade");
            dialogue_canvas.SetActive(false);
            cont_button.SetActive(false);
            cont_button_next.SetActive(true);
            FindObjectOfType<SimpleMovement>().enabled = true;

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
    IEnumerator wait()
    {
        yield return new WaitForSeconds(1.1f);
        dialogue_canvas.SetActive(true);
        DisplayNextSentence();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("NPC_tutorial"))
        {
            if (names.Count() == 6)
            {
                dialogue_canvas.SetActive(true);
                keys.gameObject.SetActive(false);
                DisplayNextSentence();

            }
            if (names.Count() == 3)
            {
                popup.SetActive(true);

            }


        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
       
        if (names.Count() == 3)
        {
            popup.SetActive(false);

        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("NPC_tutorial"))
        {
            
            if (names.Count() == 3)
            {
                popup.SetActive(true);

            }


        }
    }
}
