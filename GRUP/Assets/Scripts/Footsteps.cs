using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    public PlayerController cc;
    public AudioSource audio;

    private void Start()
    {
        
    }

    void Update()
    {
        if(cc.isMoving && audio.isPlaying == false)
        {
            audio.volume = Random.Range(0.8f, 1f);
            audio.pitch = Random.Range(0.8f, 1.1f);
            audio.Play();
        }
    }
}
