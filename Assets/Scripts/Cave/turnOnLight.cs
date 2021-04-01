﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turnOnLight : MonoBehaviour
{
    public GameObject light;
    public GameObject light_player;
    public List<GameObject> eyes;
  
    void OnTriggerEnter2D(Collider2D col)
    {
        if (light_player.activeSelf)
        {
            light.SetActive(true);
            foreach (GameObject eye in eyes)
                eye.SetActive(false);
        }
    }
    
}