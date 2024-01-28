using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingAnimation : MonoBehaviour
{
    public void Bang()
    {
        FindObjectOfType<SceneAnimator>().PlayBang();
    }

    public void ShowLose()
    {
        //Bang
        FindObjectOfType<StatusBar>().Lose();
    }
}
