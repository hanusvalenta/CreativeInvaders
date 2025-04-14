using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public  Game instance;
    public AudioClip Music;
    public float MusicVolume = 0.5f;
    public bool ShouldLoop = true;
    public  AudioClip Killed;
    public  float KilledVolume = 0.5f;
     AudioSource audioSourcedva;
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

    public void PlayKilledSound()
    {
        Debug.Log("PlayKilledSound called");
        audioSourcedva = gameObject.AddComponent<AudioSource>();
        audioSourcedva.clip = Killed;
        audioSourcedva.volume = KilledVolume;
        audioSourcedva.Play();
    }

    void Update()
    {
        
    }
}
