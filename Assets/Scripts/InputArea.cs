using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InputArea : MonoBehaviour
{
    [SerializeField] TMP_Text statusText;
    MusicNote musicNoteInside = null;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (musicNoteInside == null) { Debug.Log("Shame"); }
            else
            {
                Debug.Log("Nice");
                GameObject musicObj = musicNoteInside.gameObject;
                musicNoteInside = null;
                Destroy(musicObj);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<MusicNote>() != null)
        {
            musicNoteInside = collision.GetComponent<MusicNote>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<MusicNote>() != null && musicNoteInside != null)
        {
            musicNoteInside = null;
            Debug.Log("Shame");
        }
    }
}
