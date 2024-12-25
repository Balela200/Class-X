using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddComponent : MonoBehaviour
{
    public GameObject Win;
    public void Exit()
    {
        Application.Quit();
    }

    public void  WinBot()
    {
        bool isPageOpen = Win.activeSelf;

        if (isPageOpen)
        {
            Win.SetActive(false);
        }
        else
        {
            Win.SetActive(true);
        }
    }
}
