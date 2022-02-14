using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public GameObject sprite_text;
    public GameObject light;


    // Update is called once per frame
    void Update()
    {
        float distance = ComputeDistance();

        if (distance < 2)
            sprite_text.SetActive(true);
        else
            sprite_text.SetActive(false);


        if (sprite_text.gameObject.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                light.SetActive(true);
                player.GetComponent<Animator>().SetBool("Orb",true);
                this.gameObject.SetActive(false);

            }

        }

      

    }

    private float ComputeDistance()
    {
        float dist = Vector3.Distance(this.gameObject.transform.position, player.transform.position);
        return dist;
    }
}
