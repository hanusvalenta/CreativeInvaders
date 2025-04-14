using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public AudioClip Music;
    public float MusicVolume = 0.5f;
    public bool ShouldLoop = true;
    void Start()
    {
        if (Music != null)
        {
            AudioSource audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.clip = Music;
            audioSource.volume = MusicVolume;
            audioSource.loop = ShouldLoop;
            audioSource.Play();
        } 
    }
    void Update()
    {
        
    }
}
