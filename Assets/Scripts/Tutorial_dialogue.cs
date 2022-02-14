using System.Collections;
using UnityEngine;


public class Tutorial_dialogue : MonoBehaviour
{
    // Start is called before the first frame update
    public ExecuteDialogue manager;
    public GameObject npc;
    public GameObject keys;
    public GameObject popup;
    public GameObject collide;

    private bool move = true;
    private bool start = true;



    void Update()
    {
        if (!move)
            FindObjectOfType<SimpleMovement>().enabled = false;
        else
            FindObjectOfType<SimpleMovement>().enabled = true;

        switch (Tutorial.state)
        {
            case 0:
                if (start)
                    StartCoroutine("wait");


                if (!manager.dialogue_canvas.activeSelf && !start)
                {
                    if (npc.transform.position.x < 17)
                    {
                        Vector3 horizontal = new Vector3(1.0f, 0.0f, 0.0f);
                        npc.transform.position = npc.transform.position + horizontal * Time.deltaTime * 6;
                    }
                    keys.SetActive(true);
                    move = true;
                }

                break;
            case 1:
                if (start)
                {
                    keys.SetActive(false);
                    move = false;
                    manager.GetDialogueFromFile(Application.dataPath + "/Text Files/" + "tutorial1.txt");
                    manager.dialogue_canvas.SetActive(true);
                    manager.DisplayNextSentence();
                    start = false;
                }
                if (!manager.dialogue_canvas.activeSelf)
                    popup.SetActive(true);

                break;
            case 2:
                if (start)
                {
                    popup.SetActive(false);
                    move = false;
                    manager.GetDialogueFromFile(Application.dataPath + "/Text Files/" + "tutorial2.txt");
                    manager.dialogue_canvas.SetActive(true);
                    manager.DisplayNextSentence();
                    start = false;
                }
                if (!manager.dialogue_canvas.activeSelf)
                {
                    npc.GetComponent<Animator>().SetTrigger("Fade");
                    move = true;
                }
                break;
        }
        if (popup.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Tutorial.NextFile();
                start = true;

            }
        }

    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(2f);
        move = false;
        start = false;
        manager.GetDialogueFromFile(Application.dataPath + "/Text Files/" + "tutorial.txt");
        manager.dialogue_canvas.SetActive(true);
        manager.DisplayNextSentence();
        StopAllCoroutines();

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("tutorial"))
        {
            Tutorial.NextFile();
            start = true;
            collide.SetActive(false);
        }
    }
}
