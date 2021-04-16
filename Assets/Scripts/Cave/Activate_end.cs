using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activate_end : MonoBehaviour
{
    public GameObject NPC;


    // Update is called once per frame
    void Update()
    {
        if (Utils.cave_checkpoints == 3)
        {
            NPC.SetActive(true);
            Utils.subsCheckpoint(3);
        }
    }
}
