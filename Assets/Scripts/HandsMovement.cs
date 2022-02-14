using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(float))]
[RequireComponent(typeof(float))]
[RequireComponent(typeof(Vector3))]

public class HandsMovement : MonoBehaviour
{
    public float speed;
    public float add_factor;
    public Vector3 direction;
    public Respawn respawn;


    private Vector3 startPos;
    private float startSpeed;
    void Start()
    {
        startPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        startSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + direction * (Time.deltaTime * speed);
        speed += add_factor;
        if (transform.position.x < startPos.x || transform.position.y < startPos.y)
            gameObject.SetActive(false);
    }

    private void Reset()
    {
        transform.position = startPos;
        speed = startSpeed;
        gameObject.SetActive(false);
        respawn.Reset();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Reset();
        }
        if (collision.CompareTag("Fire"))
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            direction = -direction;
        }
    }
}
