using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jester : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    public void GetSad()
    {
        animator.SetTrigger("Sad");
    }
    
    public void DanceRight()
    {
        animator.SetTrigger("Right");
    }

    public void DanceLeft()
    {
        animator.SetTrigger("Left");
    }

    public void DanceUp()
    {
        animator.SetTrigger("Up");
    }

    public void DanceDown()
    {
        animator.SetTrigger("Down");
    }
}
