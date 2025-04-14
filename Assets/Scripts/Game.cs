using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public AudioClip Music;
    void Start()
    {
        if (Music != null)
        {
            AudioSource audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.clip = Music;
            audioSource.Play();
        } 
    }
    void Update()
    {
        
    }
}
