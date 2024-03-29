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
    [SerializeField] AudioSource BadSound;
    MusicNote musicNoteInside = null;
    MusicHoldNote musicHoldNoteInside = null;
    MusicNoteRelease musicNoteRelease = null;

    MusicHoldNote MusicHoldNoteHolding = null;

    float timeSinceTextShown;
    [SerializeField] float lengthOfTimeTextShown = .5f;

    SpriteRenderer spriteRenderer;
    Jester jester;

    public Action OnHoldInput;
    public Action OnGoodInput;
    public Action OnBadInput;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        jester = FindObjectOfType<Jester>();
    }

    private void FixedUpdate()
    {
        if (MusicHoldNoteHolding != null)
        {
            if (OnHoldInput != null) { OnHoldInput(); }
        }
    }

    //Possibly because of Camera Confiner
    private void Update()
    {
        if (FindObjectOfType<StatusPanel>().LostOrWon()) { return; }
        if (Input.GetKeyDown(codeUsed))
        {
            if (musicNoteInside == null && musicHoldNoteInside == null) {
                ShowBadNote();
            }
            else { ShowGoodNote(); }
        }

        if (Input.GetKeyUp(codeUsed))
        {
            if (musicNoteRelease != null && MusicHoldNoteHolding != null)
            {
                ShowGoodNote();
                MusicHoldNoteHolding = null;
            }
            else if (MusicHoldNoteHolding != null)
            {
                jester.Release();
                spriteRenderer.color = Color.white;
                MusicHoldNoteHolding.MakeAreaGrey();
                MusicHoldNoteHolding = null;
            }
        }

        if (timeSinceTextShown + lengthOfTimeTextShown < Time.time)
        {
            if (MusicHoldNoteHolding == null)
            {
                spriteRenderer.color = Color.white;
            }
            statusText.gameObject.SetActive(false);
        }
    }

    void ShowGoodNote()
    {
        spriteRenderer.color = Color.green;
        statusText.text = "great";
        //GoodSound.Play();
        statusText.gameObject.SetActive(true);
        if (musicNoteInside != null)
        {
            GameObject musicObj = musicNoteInside.gameObject;
            musicNoteInside = null;
            Destroy(musicObj);

            if (codeUsed == KeyCode.LeftArrow)
            {
                jester.DanceLeft();
            }
            else if (codeUsed == KeyCode.RightArrow)
            {
                jester.DanceRight();
            }
            else if (codeUsed == KeyCode.UpArrow)
            {
                jester.DanceUp();
            }
            else if (codeUsed == KeyCode.DownArrow)
            {
                jester.DanceDown();
            }
            else
            {
                Debug.LogWarning("Keycode used that is not defined");
            }
        }
        else if (musicNoteRelease != null && MusicHoldNoteHolding != null)
        {
            //End
            GameObject musicObj = MusicHoldNoteHolding.gameObject;
            MusicHoldNoteHolding = null;
            Destroy(musicObj);
            jester.Release();
        }
        else if (musicHoldNoteInside != null)
        {
            //Start
            MusicHoldNoteHolding = musicHoldNoteInside;
            musicHoldNoteInside.GetComponent<SpriteRenderer>().enabled = false;
            musicHoldNoteInside.MakeAreaGood();

            if (codeUsed == KeyCode.LeftArrow)
            {
                jester.HoldLeft();
            }
            else if (codeUsed == KeyCode.RightArrow)
            {
                jester.HoldRight();
            }
            else if (codeUsed == KeyCode.UpArrow)
            {
                jester.HoldUp();
            }
            else if (codeUsed == KeyCode.DownArrow)
            {
                jester.HoldDown();
            }
            else
            {
                Debug.LogWarning("Keycode used that is not defined");
            }
        }

        timeSinceTextShown = Time.time;
        if (OnGoodInput != null) { OnGoodInput(); }

    }

    void ShowBadNote()
    {
        BadSound.Play();
        spriteRenderer.color = Color.red;
        statusText.text = "nay";
        statusText.gameObject.SetActive(true);
        timeSinceTextShown = Time.time;
        if (OnBadInput != null) { OnBadInput(); }
        jester.GetSad();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<MusicNote>() != null)
        {
            musicNoteInside = collision.GetComponent<MusicNote>();
        }
        if (collision.GetComponent<MusicHoldNote>() != null)
        {
            musicHoldNoteInside = collision.GetComponent<MusicHoldNote>();
        }
        if (collision.GetComponent<MusicNoteRelease>() != null)
        {
            musicNoteRelease = collision.GetComponent<MusicNoteRelease>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<MusicNote>() != null && musicNoteInside != null)
        {
            musicNoteInside = null;
            ShowBadNote();
        }
        if (collision.GetComponent<MusicHoldNote>() != null)
        {
            if (MusicHoldNoteHolding == null)
            {
                musicHoldNoteInside.MakeAreaGrey();
                musicHoldNoteInside = null;
                ShowBadNote();
            }
            else
            {
                musicHoldNoteInside = null;
            }
        }
        if (collision.GetComponent<MusicNoteRelease>() != null)
        {
            musicNoteRelease = null;
            if (MusicHoldNoteHolding != null)
            {
                jester.Release();
                MusicHoldNoteHolding = null;
            }
        }
    }
}
