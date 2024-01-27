using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusBar : MonoBehaviour
{
    [SerializeField] float incrementToMove = 25f;
    [SerializeField] Image forground;
    [SerializeField] float GoodThreshold = -200f;
    [SerializeField] float BadThrshold = -350f;
    [SerializeField] float max = 0;
    [SerializeField] float min = -550;
    // Start is called before the first frame update
    void Start()
    {
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
        if (yPos <= BadThrshold) { forground.color = Color.red; }
        else if (yPos < GoodThreshold) { forground.color = Color.black; }
        if (yPos == min)
        {
            //Trigger Lose condition
        }
    }

    void MoveBarUp()
    {
        float yPos = Mathf.Clamp(forground.transform.localPosition.y + incrementToMove, min, max);
        forground.transform.localPosition = new Vector3(forground.transform.localPosition.x, yPos, transform.localPosition.z);

        if (yPos >= GoodThreshold) { forground.color = Color.green; }
        else if (yPos > BadThrshold) { forground.color = Color.black; }
    }
}
