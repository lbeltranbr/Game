using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GameObject))]

public class HandsActivation : MonoBehaviour
{
    public GameObject hands;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            hands.SetActive(true);
    }
}
