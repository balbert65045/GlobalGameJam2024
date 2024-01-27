using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    AudioSource m_AudioSource;
    void Start()
    {
        m_AudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartMusic();
        }
    }

    void StartMusic()
    {
        if (!m_AudioSource.isPlaying) { m_AudioSource.Play(); }
    }
}
