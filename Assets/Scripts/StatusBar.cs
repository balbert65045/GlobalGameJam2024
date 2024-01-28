using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class StatusBar : MonoBehaviour
{
    [SerializeField] float incrementToMove = 25f;
    [SerializeField] GameObject forground;
    [SerializeField] float SuperGoodThreshold = -100f;
    [SerializeField] float GoodThreshold = -200f;
    [SerializeField] float BadThrshold = -350f;
    [SerializeField] float SuperBadThreshold = -450f;
    [SerializeField] float max = 0;
    [SerializeField] float min = -550;

    King king;
    bool WasMad = false;
    bool WasSuperMad = false;
    bool WasSuperHappy = false;
    bool WasHappy = false;

    public Action OnLose;

    // Start is called before the first frame update
    void Start()
    {
        king = FindObjectOfType<King>();
        InputArea[] inputAreas = FindObjectsOfType<InputArea>();
        foreach(InputArea area in inputAreas)
        {
            area.OnBadInput += MoveBarDown;
            area.OnGoodInput += MoveBarUp;
        }
    }


    void MoveBarDown()
    {
        float yPos = Mathf.Clamp(forground.transform.localPosition.y - incrementToMove, min, max);
        forground.transform.localPosition = new Vector3(forground.transform.localPosition.x, yPos, transform.localPosition.z);
        if (yPos <= SuperBadThreshold && !WasSuperMad)
        {
            king.GetSuperMad();
            WasSuperMad = true;
        }
        else if (yPos <= BadThrshold && !WasMad) {
            king.GetMad();
            WasMad = true;
        }
        else if (yPos < GoodThreshold && WasHappy) {
            WasHappy = false;
            king.GetCalm();
        }
        else if (yPos < SuperGoodThreshold && WasSuperHappy)
        {
            WasSuperHappy = false;
            king.GetHappy();
        }
        if (yPos == min)
        {
            FindObjectOfType<SceneAnimator>().Lose();
            FindObjectOfType<MusicScroller>().StopMusic();
            FindObjectOfType<AudioManager>().StopMusic();
        }
    }

    public void Lose()
    {
        if (OnLose != null) { OnLose(); }
    }

    void MoveBarUp()
    {
        float yPos = Mathf.Clamp(forground.transform.localPosition.y + incrementToMove, min, max);
        forground.transform.localPosition = new Vector3(forground.transform.localPosition.x, yPos, transform.localPosition.z);
        if (yPos >= SuperGoodThreshold && !WasSuperHappy)
        {
            WasSuperHappy = true;
            king.GetSuperHappy();
        }
        else if (yPos >= GoodThreshold && !WasHappy) {
            WasHappy = true;
            king.GetHappy();
        }
        else if (yPos > BadThrshold && WasMad) {
            WasMad = false;
            king.GetCalm();
        }
        else if ( yPos > SuperBadThreshold && WasSuperMad)
        {
            WasSuperMad = false;
            king.GetMad();
        }
    }
}
