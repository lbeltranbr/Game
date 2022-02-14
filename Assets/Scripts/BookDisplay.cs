using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookDisplay : MonoBehaviour
{
    public Camera cam;
    public GameObject book;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        { // if left button pressed...
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.name.Equals(gameObject.name))
                    book.SetActive(true);
            }
        }
    }
}
