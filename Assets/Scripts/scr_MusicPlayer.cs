using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_MusicPlayer : MonoBehaviour
{
    private static scr_MusicPlayer instance;

    private AudioSource source;
    public AudioClip[] music;

    void Awake()
    {
        source = GetComponent<AudioSource>();
        newTrack();

        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(transform.gameObject);
        }        
    }

    void Update()
    {
        if (!source.isPlaying)
        {
            newTrack();
        }
    }

    public void newTrack()
    {
        source.clip = music[Random.Range(0, music.Length)];
        source.Play();
    }
}
