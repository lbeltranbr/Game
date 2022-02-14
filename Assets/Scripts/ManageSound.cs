using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ManageSound : MonoBehaviour
{
    public List<AudioSource> music;
    public List<AudioSource> sfx;
    // Start is called before the first frame update

    void Update()
    {
        foreach (AudioSource m in music)
            m.volume = m.maxDistance*Sound.volume;
        foreach (AudioSource m in sfx)
            m.volume = m.maxDistance*Sound.SFX;
    }
}
