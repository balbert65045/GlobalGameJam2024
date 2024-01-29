using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneAnimator : MonoBehaviour
{
    [SerializeField] AudioSource Waa1;
    [SerializeField] AudioSource Waa2;
    [SerializeField] AudioSource Waa3;
    [SerializeField] AudioSource Waa4;
    [SerializeField] AudioSource Waa5;
    [SerializeField] AudioSource LightOn;
    [SerializeField] AudioSource AngryKing;
    [SerializeField] AudioSource Bang;
    [SerializeField] AudioSource GameOverGoodSong;
    [SerializeField] AudioSource GameOverSadSong;
    [SerializeField] AudioSource KingLaugh;


    [SerializeField] GameObject GameCamera;
    [SerializeField] GameObject KingCamera;
    [SerializeField] GameObject JesterCamera;

    public void GiveKingAGun()
    {
        FindObjectOfType<King>().GiveAGun();
    }

    public void PlayBang()
    {
        Bang.Play();
        StartCoroutine("WaitAndPlayGameOver");
    }

    IEnumerator WaitAndPlayGameOver()
    {
        yield return new WaitForSeconds(1f);
        GameOverSadSong.Play();
    }

    public void Lose()
    {
        GetComponent<Animator>().SetTrigger("Lose");
    }

    public void BeginWin()
    {
        GetComponent<Animator>().SetTrigger("Win");
    }

    public void JumpForJoy()
    {
        GameOverGoodSong.Play();
        FindObjectOfType<Jester>().HoldUp();
        KingLaugh.Play();
        StartCoroutine("WaitAndWin");
    }

    IEnumerator WaitAndWin()
    {
        yield return new WaitForSeconds(1f);
        Win();
    }
    public void Win()
    {
        FindObjectOfType<AudioManager>().Win();
    }

    public void PlayAngryKing()
    {
        AngryKing.Play();
    }

    public void ShowKing()
    {
        KingCamera.SetActive(true);
        GameCamera.SetActive(false);
    }

    public void ShowJester()
    {
        JesterCamera.SetActive(true);
        GameCamera.SetActive(false);
        KingCamera.SetActive(false);
    }

    public void ShowGame()
    {
        GameCamera.SetActive(true);
    }
    public void Begin()
    {
        FindObjectOfType<StartSound>().Begin();
    }

    public void TurnOnLight()
    {
        LightOn.Play();
    }

    public void PlayWaa1()
    {
        Waa1.Play();
    }

    public void PlayWaa2()
    {
        Waa2.Play();
    }

    public void PlayWaa3()
    {
        Waa3.Play();
    }

    public void PlayWaa4()
    {
        Waa4.Play();
    }

    public void PlayWaa5()
    {
        Waa5.Play();
    }
}
