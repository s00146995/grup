using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSounds : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip moveButton;
    public AudioClip selectButton;

    public void MoveSound()
    {
        audioSource.PlayOneShot(moveButton);
    }

    public void SelectSound()
    {
        audioSource.PlayOneShot(selectButton);
    }
}
