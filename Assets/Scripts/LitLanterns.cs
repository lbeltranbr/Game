using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LitLanterns : MonoBehaviour
{
    public GameObject fire;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Orb"))
        {
            fire.SetActive(true);
            gameObject.GetComponent<Collider2D>().enabled = false;
            Cave.AddCheckpoint();
        }
        
    }
}
