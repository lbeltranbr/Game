using UnityEngine;

public class Orb : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public GameObject sprite_text;
    public GameObject light_orb;


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
                player.GetComponent<Animator>().SetBool("Orb", true);
                this.gameObject.SetActive(false);
                light_orb.SetActive(true);

            }
        }
    }

    private float ComputeDistance()
    {
        float dist = Vector3.Distance(this.gameObject.transform.position, player.transform.position);
        return dist;
    }
}
