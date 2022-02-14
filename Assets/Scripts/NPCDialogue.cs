using UnityEngine;

public class NPCDialogue : MonoBehaviour
{
    public GameObject player;
    public GameObject sprite_text;
    public ExecuteDialogue manager;
    public string textFile;


    // Update is called once per frame
    void Update()
    {
        float distance = MathFunctions.ComputeDistance(this.gameObject.transform.position, player.transform.position);

        if (distance < 4)
            sprite_text.SetActive(true);
        else
            sprite_text.SetActive(false);


        if (sprite_text.gameObject.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                FindObjectOfType<SimpleMovement>().enabled = false;

                manager.GetDialogueFromFile(Application.dataPath + "/Text Files/" + textFile + ".txt");
                manager.dialogue_canvas.SetActive(true);
                manager.DisplayNextSentence();
                Cave.MemoryActivation(true);

            }
        }
        if (!manager.dialogue_canvas.activeSelf)
            FindObjectOfType<SimpleMovement>().enabled = true;


    }
}
