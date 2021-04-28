using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMovement : MonoBehaviour
{
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public Transform GroundCheck;
    public float speed;


  

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<SimpleMovement>().enabled)
        {
            /*********************** HORIZONTAL MOVEMENT ***********************/
            animator.SetFloat("Horizontal", Mathf.Abs(Input.GetAxis("Horizontal")));
            Vector3 horizontal = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f);
            if (horizontal.x > 0.01)
                spriteRenderer.flipX = false;
            else if (horizontal.x < -0.01f)
                spriteRenderer.flipX = true;

            transform.position = transform.position + horizontal * Time.deltaTime * speed;

            if (Input.GetKeyDown(KeyCode.S))
            {
                animator.SetTrigger("Spirit_walk");
                gameObject.GetComponent<AudioSource>().Play();
            }
            //Debug.Log(transform.position);
        }
    }

  
}
