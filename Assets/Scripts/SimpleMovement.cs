using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMovement : MonoBehaviour
{
    public Animator animator;
    public float speed;

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Horizontal",Input.GetAxis("Horizontal"));
        animator.SetFloat("Vertical",Input.GetAxis("Vertical"));
        Vector3 horizontal = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f);
        Vector3 vertical = new Vector3( 0.0f, Input.GetAxis("Vertical"), Input.GetAxis("Vertical"));
        transform.position = transform.position + (horizontal+vertical) * Time.deltaTime * speed;

        if(Input.GetKeyDown(KeyCode.Space))
            animator.SetTrigger("Jump");
    }
}
