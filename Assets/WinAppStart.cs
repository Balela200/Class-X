using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinAppStart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClosingApp()
    {
        AddComponent.addComponent.Win.SetActive(false);
    }
}
