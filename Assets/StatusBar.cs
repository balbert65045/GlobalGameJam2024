using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class StatusBar : MonoBehaviour
{
    [SerializeField] float incrementToMove = 25f;
    [SerializeField] Image forground;
    [SerializeField] float GoodThreshold = -200f;
    [SerializeField] float BadThrshold = -350f;
    [SerializeField] float max = 0;
    [SerializeField] float min = -550;

    King king;
    bool WasMad = false;
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
        if (yPos <= BadThrshold && !WasMad) {
            king.GetMad();
            WasMad = true;
            forground.color = Color.red;
        }
        else if (yPos < GoodThreshold && WasHappy) {
            WasHappy = false;
            king.GetCalm();
            forground.color = Color.black;
        }
        if (yPos == min)
        {
            if (OnLose != null) { OnLose(); }
        }
    }

    void MoveBarUp()
    {
        float yPos = Mathf.Clamp(forground.transform.localPosition.y + incrementToMove, min, max);
        forground.transform.localPosition = new Vector3(forground.transform.localPosition.x, yPos, transform.localPosition.z);

        if (yPos >= GoodThreshold && !WasHappy) {
            WasHappy = true;
            king.GetHappy();
            forground.color = Color.green;
        }
        else if (yPos > BadThrshold && WasMad) {
            WasMad = false;
            king.GetCalm();
            forground.color = Color.black;
        }
    }
}
