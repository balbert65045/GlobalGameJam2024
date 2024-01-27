using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicScroller : MonoBehaviour
{
    [SerializeField] float beatTempo = 1f;
    bool moveMusic = false;

    private void Start()
    {
        beatTempo = beatTempo / 60f;
    }
    void Update()
    {
        if (moveMusic)
        {
            transform.Translate(-Vector2.right * Time.deltaTime * beatTempo);
        }
    }

    public void StartMusic()
    {
        moveMusic = true;
    }
}
