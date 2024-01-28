using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    public void GiveAGun()
    {
        animator.SetTrigger("Gun");
    }
    public void GetSuperMad()
    {
        animator.SetTrigger("SuperMad");
    }
    public void GetMad()
    {
        animator.SetTrigger("Mad");
    }

    public void GetCalm()
    {
        animator.SetTrigger("Calm");
    }

    public void GetHappy()
    {
        animator.SetTrigger("Happy");
    }

    public void GetSuperHappy()
    {
        animator.SetTrigger("SuperHappy");
    }
}
