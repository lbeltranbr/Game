using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turnOnLight : MonoBehaviour
{
    public GameObject light;
    //public GameObject sprite_text;

    //private bool on = false;

    // Update is called once per frame
    void Update()
    {
        /*float distance = ComputeDistance();

        if (distance < 2)
            sprite_text.SetActive(true);
        else
            sprite_text.SetActive(false);

        if (sprite_text.gameObject.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                on = true;
            }

        }*/
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        //Debug.Log("OnCollisionEnter2D");
        light.SetActive(true);
    }
    /*private float ComputeDistance()
    {
        float dist = Vector3.Distance(this.gameObject.transform.position, player.transform.position);
        return dist;
    }*/
}
