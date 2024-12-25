using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour
{
    [Header("Input")]
    public TMP_InputField InputPlay;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        InputField();
    }

    public void InputField()
    {
        if(InputPlay.text.ToLower() == "play")
        {
            SceneManager.LoadScene("GameManager");
        }
        else if(InputPlay.text == "Exit")
        {
            Application.Quit();
        }
        else
        {
            Debug.Log("Error");
        }
    }
}
