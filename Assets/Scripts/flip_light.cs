using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flip_light : MonoBehaviour
{
    public GameObject player;
    private Vector3 v1 = new Vector3(-0.7f, -0.05f, 0);
    private Vector3 v2 = new Vector3( 0.7f, -0.05f, 0);
    // Update is called once per frame
    void Update()
    {
        //Debug.Log(player.GetComponent<SpriteRenderer>().flipX);
        if (gameObject.activeSelf)
        {
            if (player.GetComponent<SpriteRenderer>().flipX)
                gameObject.transform.position = player.transform.position + v1;
            else
                gameObject.transform.position = player.transform.position + v2;
        }
    }
}
