
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using System;

public class TutorialBookPageFlip : UdonSharpBehaviour
{

    public GameObject[] tutorialPages;
    [UdonSynced]
    public int currentPage;

    void Start()
    {
        currentPage = 0;
        UpdatePages();
    }

    public void UpdatePages()
    {
        foreach(GameObject page in tutorialPages)
        {
            page.SetActive(false);
        }
        tutorialPages[currentPage].SetActive(true);
    }
    public void PageCountUp()
    {
        currentPage++;
        if (currentPage >= tutorialPages.Length)
        {
            currentPage = 0;
            Debug.Log(currentPage);
        }
        Networking.SetOwner(Networking.LocalPlayer, gameObject);
        RequestSerialization();

        UpdatePages();
    }

    public void PageCountDown()
    {
        currentPage--;
        if (currentPage < 0)
        {
            currentPage = tutorialPages.Length - 1;
            Debug.Log(currentPage);
        }
        Networking.SetOwner(Networking.LocalPlayer, gameObject);
        RequestSerialization();

        UpdatePages();
    }
    public override void OnDeserialization()
    {
        UpdatePages();
    }
}
