using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSound : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] float speedOfBeat = .05f;
    float timer = 0;
    bool start = false;
    int timeing = 3;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Begin()
    {
        audioSource.Play();
        StartCoroutine("WaitAndGo");
    }

    IEnumerator WaitAndGo()
    {
        while(timeing >= -1)
        {
            if (timeing == 3)
            {
                FindObjectOfType<StatusPanel>().Show3();
            }
            if (timeing == 2)
            {
                FindObjectOfType<StatusPanel>().Show2();
            }
            if (timeing == 1)
            {
                FindObjectOfType<StatusPanel>().Show1();
            }
            if (timeing == 0)
            {
                FindObjectOfType<AudioManager>().StartMusic();
                FindObjectOfType<StatusPanel>().ShowGo();
                FindObjectOfType<Jester>().Go();
            }
            if (timeing == -1)
            {
                FindObjectOfType<StatusPanel>().HideGo();
            }
            timeing--;
            yield return new WaitForSeconds(speedOfBeat);
        }
    }
}
