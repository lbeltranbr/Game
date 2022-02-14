using UnityEngine;

public class Crack : MonoBehaviour
{
    public Collider2D floor;
    public GameObject player;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Animator anim = player.GetComponent<Animator>();
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("fade_in_out"))
                floor.enabled = true;
            else
                floor.enabled = false;

        }

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Animator anim = player.GetComponent<Animator>();
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("fade_in_out"))
                floor.enabled = true;
            else
                floor.enabled = false;

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Animator anim = player.GetComponent<Animator>();
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("fade_in_out"))
                floor.enabled = true;
            else
                floor.enabled = false;

        }
    }

}
