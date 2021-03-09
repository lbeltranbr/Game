﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandsMovement : MonoBehaviour
{

    public float speed;
    public float add_factor;
    public Transform player;
    public GameObject light;
    


    private Vector3 startPos;
    private Vector3 startPosPlayer;

    private float startSpeed;
    private int state;
    private void Awake()
    {
        startPos = transform.position;
        startPosPlayer = player.position;
        startSpeed = speed;
        state = 0;
    }

    // Update is called once per frame
    void Update()
    {
     

        Vector3 horizontal = new Vector3(1.0f, 0.0f, 0.0f);
        Vector3 vertical = new Vector3(0.0f, 1.0f, 0.0f);


        switch (state) {
            case 0: //forward
                transform.position = transform.position + horizontal * Time.deltaTime * speed;
                speed += add_factor;
                break;
            case 1: //reset
                ResetHands();
                ResetPlayer();
                ResetLights();
                state = 0;
                break;
            case 2: //Backwards Left
                transform.position = transform.position - horizontal * Time.deltaTime * speed*2;
             
                if (transform.position.x < startPos.x)  
                    gameObject.SetActive(false);
                break;
            case 3://Up
                transform.position = transform.position + vertical * Time.deltaTime * speed * 2;

                if (transform.position.y > 11)
                    gameObject.SetActive(false);
                break;

        };

        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            state = 1;
        if (collision.tag == "Light")
        {
            if(gameObject.tag=="Left_hand")
                state = 2;
            else
                state = 3;

        }
    }

    private void ResetHands()
    {
        transform.position = startPos;
        speed = startSpeed;

    }
    private void ResetPlayer()
    {
        player.position = startPosPlayer;

    }
    private void ResetLights()
    {
        light.SetActive(false);

    }
}
