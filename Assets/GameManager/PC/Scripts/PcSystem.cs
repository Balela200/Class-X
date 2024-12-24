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

    bool isUnity;
    bool isVisualStudio;
    [Header("Date")]
    public TMP_Text dateText; 
    public TMP_Text timeText;
    void Update()
    {
        TimeForThisPc();

        // App
        if(isUnity)
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

        if(isVisualStudio)
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
    }

    public void VisualStudio()
    {
        isUnity = false;

        isVisualStudio = true;
    }
}
