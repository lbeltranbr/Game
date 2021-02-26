using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public GameObject sprite;
   

    // Update is called once per frame
    void Update()
    {
        float distance = ComputeDistance();

        if (distance < 4)
            sprite.SetActive(true);
        else
            sprite.SetActive(false);

    }

    private float ComputeDistance()
    {
        float dist = Vector3.Distance(this.gameObject.transform.position, player.transform.position);
        return dist;
    }
}
