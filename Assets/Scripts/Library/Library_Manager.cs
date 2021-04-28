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


    // Update is called once per frame
    void Update()
    {
        if (Utils.riddle)
        {
            bigNPC.GetComponent<EnterCave_dialogue>().enabled = false;
            bigNPC.GetComponent<EnterCave_dialogue>().path="LibraryNPC2";
            bigNPC.GetComponent<Input_Answer>().enabled = true;

        }

        if (Utils.error)
        {
            smoke.SetActive(true);
            SceneManager.LoadScene("Library", LoadSceneMode.Single);
        }


        
    }

    public void CheckAnswer()
    {
        if (ans.text != "Coffin" || ans.text != "coffin" || ans.text != "COFFIN")
        {
            StartCoroutine("restart");
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
