using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
using UnityEngine.UI;

public class End_Cave : MonoBehaviour
{
    private Queue<string> dialog = new Queue<string>();
    private Queue<string> names = new Queue<string>();
    private bool first = true;
    private bool trigger = false;

    public GameObject dialogue_canvas;
    public GameObject cont_button;
    public GameObject deac_cont_button;

    public Text nameText;
    public Text dialogueText;


    private void Start()
    {
        string p = Application.dataPath + "/Text Files/" + "End_Cave.txt";
        List<string> lines = File.ReadAllLines(p).ToList();
        int i = 0;
        names.Clear();
        dialog.Clear();

        foreach (string line in lines)
        {
            if (Utils.c_1) //if the user interacts with the NPC
            {
                if (i % 2 == 0 &&i!=4&&i!=8)
                    names.Enqueue(line);
              
                if(i % 2 != 0&&i !=5&&i!=9)
                    dialog.Enqueue(line);
                
            }
            if (!Utils.c_1) //if the user interacts with the NPC
            {
                if (i % 2 == 0 && i != 2 && i != 6)
                    names.Enqueue(line);
                
                if (i % 2 != 0 && i != 3 && i != 7)
                    dialog.Enqueue(line);
                
            }


            i++;
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        
     

    }
    IEnumerator wait()
    {
        Animator anim = gameObject.GetComponent<Animator>();
        if (!trigger)
        {
            anim.SetTrigger("fade");
            trigger = true;
        }
        yield return new WaitForSeconds(1.0f);
        gameObject.SetActive(false);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(first)
            Activate();
    }

    public void DisplayNextSentence()
    {
        if (names.Count == 0)
        {
            dialogue_canvas.SetActive(false);
            StartCoroutine("wait");
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
  
    public void Activate()
    {
        dialogue_canvas.SetActive(true);
        deac_cont_button.SetActive(false);
        cont_button.SetActive(true);
        DisplayNextSentence();
        first = false;
        FindObjectOfType<SimpleMovement>().enabled = false;

    }
}

