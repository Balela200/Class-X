using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddComponent : MonoBehaviour
{
    public static AddComponent addComponent;
    public Animator anim;
    public GameObject Win;

    private void Start()
    {
        addComponent = this;
    }
    public void Exit()
    {
        Application.Quit();
    }

    public void  WinBot()
    {
        bool isPageOpen = Win.activeSelf;

        if (isPageOpen)
        {
            //Win.SetActive(false);
            anim.SetTrigger("Closing");
        }
        else
        {
            Win.SetActive(true);
        }
    }
}
