using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSound : MonoBehaviour
{
    AudioSource audioSource;
    float timeOfClip = 1f;
    bool start = false;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeSinceLevelLoad > timeOfClip && !start)
        {
            start = true;
            FindObjectOfType<AudioManager>().StartMusic();
            FindObjectOfType<StatusPanel>().ShowGo();
            FindObjectOfType<Jester>().Go();
        }
    }
}
