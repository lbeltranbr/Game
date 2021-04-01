using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandsManager : MonoBehaviour
{
    public GameObject hands;
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player")
            hands.SetActive(true);
    }
}
