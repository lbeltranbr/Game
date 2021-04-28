using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book_manager : MonoBehaviour
{
    public Camera cam;
    public List<GameObject> books;

    private string name;
    // Start is called before the first frame update
    private void Start()
    {
        name = gameObject.tag;
        //Debug.Log(name);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        { // if left button pressed...

            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                    //book.SetActive(true);
                foreach (GameObject it in books)
                    if(it.CompareTag(name))
                        it.SetActive(true);
            }
        }
    }
}
