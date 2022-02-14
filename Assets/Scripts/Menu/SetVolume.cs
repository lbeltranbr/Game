using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetVolume : MonoBehaviour
{

    // Update is called once per frame
    private void Awake()
    {
        if (gameObject.CompareTag("volume"))
            gameObject.GetComponent<Slider>().value = Utils.volume;
        else
            gameObject.GetComponent<Slider>().value = Utils.SFX;
    }
   
}
