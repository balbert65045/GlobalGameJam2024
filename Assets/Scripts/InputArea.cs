using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class InputArea : MonoBehaviour
{
    [SerializeField] KeyCode codeUsed;
    [SerializeField] TMP_Text statusText;
    MusicNote musicNoteInside = null;

    float timeSinceTextShown;
    [SerializeField] float lengthOfTimeTextShown = .5f;

    SpriteRenderer spriteRenderer;

    public Action OnGoodInput;
    public Action OnBadInput;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(codeUsed))
        {
            if (musicNoteInside == null) { ShowBadNote(); }
            else { ShowGoodNote(); }
        }
        
        if (timeSinceTextShown + lengthOfTimeTextShown < Time.time)
        {
            spriteRenderer.color = Color.black;
            statusText.gameObject.SetActive(false);
        }
    }

    void ShowGoodNote()
    {
        spriteRenderer.color = Color.green;
        statusText.text = "NICE";
        statusText.gameObject.SetActive(true);
        GameObject musicObj = musicNoteInside.gameObject;
        musicNoteInside = null;
        Destroy(musicObj);
        timeSinceTextShown = Time.time;
        if (OnGoodInput != null) { OnGoodInput(); }
    }

    void ShowBadNote()
    {
        spriteRenderer.color = Color.red;
        statusText.text = "BOO";
        statusText.gameObject.SetActive(true);
        timeSinceTextShown = Time.time;
        if (OnBadInput != null) { OnBadInput(); }
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
            ShowBadNote();
        }
    }
}
