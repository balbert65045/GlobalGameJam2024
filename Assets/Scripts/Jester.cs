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
        animator.speed = (FindObjectOfType<MusicScroller>().beatTempo / 60f) / 2.5f;
         StatusBar status = FindObjectOfType<StatusBar>();
        status.OnLose += Die;

    }

    public void Release()
    {
        Debug.Log("Relase");

        animator.SetBool("HoldLeft", false);
        animator.SetBool("HoldRight", false);
        animator.SetBool("HoldUp", false);
        animator.SetBool("HoldDown", false);
    }

    public void HoldLeft()
    {
        animator.SetBool("HoldLeft", true);
    }

    public void HoldRight()
    {
        animator.SetBool("HoldRight", true);
    }
    public void HoldUp()
    {
        animator.SetBool("HoldUp", true);
    }
    public void HoldDown()
    {
        animator.SetBool("HoldDown", true);
    }

    void Die()
    {
        animator.SetTrigger("Dead");
    }

    public void Go()
    {
        animator.SetTrigger("Go");
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
