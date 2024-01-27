using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicHoldNote : MonoBehaviour
{
    [SerializeField] SpriteRenderer HoldArea;
    [SerializeField] SpriteRenderer ReleaseNote;

    public void MakeAreaGood()
    {
        HoldArea.color = Color.green;
    }

    public void MakeAreaGrey()
    {
        HoldArea.color = Color.gray;
        ReleaseNote.color = Color.gray;
    }
}
