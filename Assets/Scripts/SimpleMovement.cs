using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMovement : MonoBehaviour
{
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public Transform GroundCheck;
    public float speed;
    public float JumpForce;

    private float GroundRad = .1f;
    private bool m_Grounded = true;
    private bool jump = false;
    private Rigidbody2D m_Rigidbody2D;
    private Vector3 vertical = new Vector3(0.0f, 0.0f, 0.0f);

    private const float GRAVITY = 10f;


    private void Start()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {

        /*********************** HORIZONTAL MOVEMENT ***********************/
        animator.SetFloat("Horizontal", Mathf.Abs(Input.GetAxis("Horizontal")));
        Vector3 horizontal = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f);
        if (horizontal.x > 0.01)
            spriteRenderer.flipX = false;
        else if (horizontal.x < -0.01f)
            spriteRenderer.flipX = true;

        transform.position = transform.position + horizontal  * Time.deltaTime * speed;

        if (Input.GetKeyDown(KeyCode.S))
        {
            animator.SetTrigger("Spirit_walk");
        }
            //Debug.Log(transform.position);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("crack"))
        {
            
        }


    }
}
