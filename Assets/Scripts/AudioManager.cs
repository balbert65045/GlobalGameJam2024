using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    AudioSource m_AudioSource;
    [SerializeField] float SongLength = 120;
    float timeSongStarted;
    bool songOver = false;

    public Action OnWin;
    void Start()
    {
        m_AudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeSinceLevelLoad > SongLength + timeSongStarted && !songOver)
        {
            songOver = true;
            if (OnWin != null) { OnWin(); }
        }
    }

    public void StartMusic()
    {
        if (!m_AudioSource.isPlaying) {
            FindObjectOfType<MusicScroller>().StartMusic();
            timeSongStarted = Time.timeSinceLevelLoad;
            m_AudioSource.Play();
        }
    }
}
