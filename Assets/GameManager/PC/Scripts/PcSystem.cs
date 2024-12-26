using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PcSystem : MonoBehaviour
{
    [Header("App")]
    public GameObject UnityApp;
    public GameObject UnityAppOn;
    public GameObject UnityAppOff;

    public GameObject VisualStudioApp;
    public GameObject VisualStudioOn;
    public GameObject VisualStudioOff;

    public GameObject VLCApp;
    public GameObject VLCOn;
    public GameObject VLCOff;

    bool isUnity;
    bool isVisualStudio;
    bool isVLC;
    [Header("Date")]
    public TMP_Text dateText; 
    public TMP_Text timeText;
    void Update()
    {
        TimeForThisPc();

        // App
        if (isUnity)
        {
            UnityAppOn.SetActive(true);
            UnityAppOff.SetActive(false);

            UnityApp.SetActive(true);
        }
        else
        {
            UnityAppOn.SetActive(false);
            UnityAppOff.SetActive(true);

            UnityApp.SetActive(false);
        }

        if (isVisualStudio)
        {
            VisualStudioOn.SetActive(true);
            VisualStudioOff.SetActive(false);

            VisualStudioApp.SetActive(true);
        }
        else
        {
            VisualStudioOn.SetActive(false);
            VisualStudioOff.SetActive(true);

            VisualStudioApp.SetActive(false);
        }

        if (isVLC)
        { 
            VLCOn.SetActive(true);
            VLCOff.SetActive(false);

            VLCApp.SetActive(true);
        }
        else
        {
            VLCOn.SetActive(false);
            VLCOff.SetActive(true);

            VLCApp.SetActive(false);
        }
    }

    void TimeForThisPc()
    {
        string currentDate = System.DateTime.Now.ToString("yyyy/MM/dd");

        string currentTime = System.DateTime.Now.ToString("HH:mm tt");

        if (dateText != null)
        {
            dateText.text = currentDate;
        }

        if (timeText != null)
        {
            timeText.text = currentTime;
        }
    }

    public void Unity()
    {
        isUnity = true;

        isVisualStudio = false;

        isVLC = false;
    }

    public void VisualStudio()
    {
        isUnity = false;

        isVisualStudio = true;

        isVLC = false;
    }

    public void VLC()
    {
        isUnity = false;

        isVisualStudio = false;

        isVLC = true;
    }
}
