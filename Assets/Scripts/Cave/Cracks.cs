using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cracks : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public GameObject floor;
    public Animator anim;
    public GameObject hand;
    public GameObject cave_guy;


    //public Vector3 startPosPlayer;
    public Vector3 startPosHand;

    private bool out_anim = false;
    private Vector3 startPosPlayer;


    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.y < -7)
            StartCoroutine("playAnim");

        if (Utils.cave_checkpoints == 0)
            startPosPlayer = new Vector3(-64, -4, 1);
        if (Utils.cave_checkpoints == 1)
            startPosPlayer = new Vector3(13.8f, -4, 1);
        if (Utils.cave_checkpoints == 2)
            startPosPlayer = new Vector3(63, -4, 1);


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Animator anim = player.GetComponent<Animator>();
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("fade_in_out"))
                floor.SetActive(true);
            else
                floor.SetActive(false);
        }

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Animator anim = player.GetComponent<Animator>();
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("fade_in_out"))
                floor.SetActive(true);
            else
                floor.SetActive(false);

        }
    }

    IEnumerator playAnim()
    {
        if (!out_anim)
        {
            anim.SetTrigger("out");
            out_anim = true;
        }

        yield return new WaitForSeconds(1.0f);

        player.transform.position = startPosPlayer;
        //Debug.Log("startposplayer: " + startPosPlayer);
        //Debug.Log("player: " + player.transform.position);
        hand.transform.position = startPosHand;
        hand.SetActive(false);
        if (Utils.cave_checkpoints == 0)
            cave_guy.SetActive(true);
        //ResetHands();
        anim.SetTrigger("in");
        yield return new WaitForSeconds(2.0f);

        out_anim = false;

    }
}
