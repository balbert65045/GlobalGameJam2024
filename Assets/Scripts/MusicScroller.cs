using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicScroller : MonoBehaviour
{
    public float beatTempo = 1f;
    float BeatSpeed;
    bool moveMusic = false;

    private void Start()
    {
        BeatSpeed = beatTempo / 60f;
        StatusBar status = FindObjectOfType<StatusBar>();
        status.OnLose += StopMusic;
    }

    void StopMusic()
    {
        moveMusic = false;
    }
    void Update()
    {
        if (moveMusic)
        {
            transform.Translate(-Vector2.right * Time.deltaTime * BeatSpeed);
        }
    }

    public void StartMusic()
    {
        moveMusic = true;
    }
}
