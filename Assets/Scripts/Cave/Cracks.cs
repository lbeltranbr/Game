using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cracks : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Animator anim = player.GetComponent<Animator>();
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("fade_in_out"))
            {
                Debug.Log("walking");
            }

        }

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Animator anim = player.GetComponent<Animator>();
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("fade_in_out"))
            {
                Debug.Log("walking");
            }
            else
                anim.SetTrigger("fall");

        }
    }
}
