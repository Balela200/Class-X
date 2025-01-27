using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinAppStart : MonoBehaviour
{
    public void ClosingApp()
    {
        AddComponent.addComponent.Win.SetActive(false);
    }
}
