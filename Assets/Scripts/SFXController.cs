using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXController : MonoBehaviour
{
    public AudioSource ShootingSound;

    public void PlayShootingSound()
    {
        ShootingSound.Play();
    }
}
