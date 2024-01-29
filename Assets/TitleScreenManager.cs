using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreenManager : MonoBehaviour
{
    [SerializeField] GameObject TitleScreen;
    [SerializeField] GameObject CreditsScreen;
    public void ShowCredits()
    {
        TitleScreen.SetActive(false);
        CreditsScreen.SetActive(true);
    }

    public void HideCredits()
    {
        TitleScreen.SetActive(true);
        CreditsScreen.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
