using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GameObject))]
[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(GameObject))]
[RequireComponent(typeof(GameObject))]

public class Respawn : MonoBehaviour
{
    public GameObject player;
    public Collider2D floor;
    public GameObject animOut;
    public GameObject NPC;

    public void Reset()
    {
        if (Cave.checkPoints == 0)
            player.transform.position = new Vector3(33f, -3.6f, 0f);
        if (Cave.checkPoints == 1)
            player.transform.position = new Vector3(57f, -3.6f, 0f);
        if (Cave.checkPoints == 2)
            player.transform.position = new Vector3(93f, -3.6f, 0f);
        if (Cave.checkPoints == 3)
            player.transform.position = new Vector3(132f, -3.6f, 0f);
        floor.enabled = true;
        NPC.SetActive(true);
        StartCoroutine(Fade());
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Reset();
    }
    
    IEnumerator Fade()
    {
        animOut.SetActive(true);
        yield return new WaitForSeconds(2f);
        animOut.SetActive(false);
    }
}
