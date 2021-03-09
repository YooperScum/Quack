using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPause : MonoBehaviour
{
    [SerializeField] BoolVar isPaused;
    [SerializeField] FloatVar soundVolume;
    [SerializeField] AudioSource sound;

    void Start()
    {
        
    }

    void Update()
    {
        sound.volume = soundVolume.Value;

        if (isPaused.Value == true)
        {
            sound.enabled = false;
        }
        else
        {
            sound.enabled = true;
        }
    }
}
