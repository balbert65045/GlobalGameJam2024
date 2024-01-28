using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    AudioSource m_AudioSource;
    [SerializeField] float SongLength = 120;
    float timeSongStarted;
    bool stopped = false;

    public Action OnWin;

    SpriteRenderer m_spotlight;
    int colorIndex = 0;
    float timeOfLightChange;
    float timeSinceMusicStarted;
    void Start()
    {
        m_spotlight = FindObjectOfType<spotlight>().GetComponent<SpriteRenderer>();
        m_AudioSource = GetComponent<AudioSource>();
        float speed = FindObjectOfType<MusicScroller>().beatTempo / 60;
        float timing = (1 / speed);
        timeOfLightChange = timing * 2;
        StatusBar status = FindObjectOfType<StatusBar>();
    }

    public void StopMusic()
    {
        m_AudioSource.Stop();
        stopped = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeSinceLevelLoad > SongLength + timeSongStarted && !stopped)
        {
            StopMusic();
            if (OnWin != null) { FindObjectOfType<SceneAnimator>().BeginWin(); }
        }
        if (m_AudioSource.isPlaying)
        {
            if (Time.timeSinceLevelLoad > timeSinceMusicStarted + timeOfLightChange)
            {
                timeSinceMusicStarted += timeOfLightChange;
                ChangeColor();
            }
        }
    }

    public void Win()
    {
        if (OnWin != null) { OnWin(); }
    }

    void ChangeColor()
    {
        colorIndex++;
        if (colorIndex >= 4) { colorIndex = 0; }
        if (colorIndex == 0)
        {
            m_spotlight.color = Color.blue;
        }
        else if(colorIndex == 1)
        {
            m_spotlight.color = Color.red;
        }
        else if(colorIndex == 2)
        {
            m_spotlight.color = Color.green;
        }
        else if(colorIndex == 3)
        {
            m_spotlight.color = Color.yellow;
        }
    }

    public void StartMusic()
    {
        if (!m_AudioSource.isPlaying) {
            timeSinceMusicStarted = Time.timeSinceLevelLoad;
            FindObjectOfType<MusicScroller>().StartMusic();
            timeSongStarted = Time.timeSinceLevelLoad;
            m_AudioSource.Play();
        }
    }
}
