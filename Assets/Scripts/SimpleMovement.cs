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

        /*********************** VERTICAL MOVEMENT ***********************/

        if (Input.GetKeyDown(KeyCode.Space))
        {
         
            if (m_Grounded)
            {
                Debug.Log("caca");
                // Add a vertical force to the player.
                m_Grounded = false;
                jump = true;
                //m_Rigidbody2D.AddForce(new Vector2(0f, JumpForce));
                vertical.y = JumpForce * 0.5f;
                //vertical = new Vector3(0.0f, 1.0f, 0.0f);

                animator.SetBool("Grounded", m_Grounded);

            }
        }
        if (!m_Grounded){
            if (transform.position.y > -2.5)
            {
                vertical.y = 0f;
                jump = false;
            }
        }
        
            transform.position = transform.position + (horizontal + vertical) * Time.deltaTime * speed;

            //Debug.Log(transform.position);
    }

    private void FixedUpdate()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(GroundCheck.position, GroundRad);
        if (!jump)
        {
            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].gameObject != gameObject)
                {
                    m_Grounded = true;
                    animator.SetBool("Grounded", m_Grounded);

                }
            }
        }
        
    }
}
