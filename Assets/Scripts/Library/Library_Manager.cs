using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Library_Manager : MonoBehaviour
{
    public GameObject bigNPC;
    public GameObject smoke;
    public GameObject player;
    public Text ans;
    public GameObject pause;
    public GameObject col;
    public GameObject memory;


    // Update is called once per frame
    private void Awake()
    {
        Utils.Error(false);
    }
    void Update()
    {
        if (Utils.riddle)
        {
            bigNPC.GetComponent<EnterCave_dialogue>().enabled = false;
            bigNPC.GetComponent<EnterCave_dialogue>().path="LibraryNPC2";
            bigNPC.GetComponent<Input_Answer>().enabled = true;
            col.SetActive(false);

        }

            
    }

    public void CheckAnswer()
    {
        //ERROR
        if (ans.text != "Coffin" && ans.text != "coffin" && ans.text != "COFFIN")
        {
            Utils.Error(true);

            StartCoroutine("restart");
        }
        else //CORRECT
        {
            Utils.DeactivateRiddle();
            player.GetComponent<SimpleMovement>().enabled = true;
            bigNPC.GetComponent<Input_Answer>().enabled = false;
            memory.SetActive(true);
        }

    }
    IEnumerator restart()
    {
        smoke.SetActive(true);
        player.GetComponent<SimpleMovement>().enabled = false;
        pause.SetActive(false);
        yield return new WaitForSeconds(4.0f);
        SceneManager.LoadScene("Library", LoadSceneMode.Single);


    }
}
