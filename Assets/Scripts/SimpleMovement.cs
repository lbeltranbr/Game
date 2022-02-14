using UnityEngine;

public class SimpleMovement : MonoBehaviour
{
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public GameObject mainCam;
    public GameObject nextLevelCam;
    public float speed;

    private int mode;
    private void Start()
    {
        mode = 0;
    }

    // Update is called once per frame
    void Update()
    {
        switch (mode)
        {
            case 0:

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

                break;
            case 1:
                mainCam.SetActive(false);
                nextLevelCam.SetActive(true);
                speed = 2;
                animator.SetFloat("Horizontal", 1);
                horizontal = new Vector3(1, 0.0f, 0.0f);
                spriteRenderer.flipX = false;
                transform.position = transform.position + horizontal * Time.deltaTime * speed;

                break;

        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("NextLevel"))
            mode = 1;
    }
    


}
