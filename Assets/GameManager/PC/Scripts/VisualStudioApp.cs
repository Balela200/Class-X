using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualStudioApp : MonoBehaviour
{
    [Header(".CS")]
    public GameObject PlayerControllor_cs;
    public GameObject VRSystem_cs;
    public GameObject Key_cs;

    bool isPlayerControllor_cs;
    bool isVRSystem_cs;
    bool isKey_cs;

    [Header("On or Off")]
    public GameObject PlayerControllor_Off;
    public GameObject PlayerControllor_On;

    public GameObject VRSystem_Off;
    public GameObject VRSystem_On;

    public GameObject Key_Off;
    public GameObject Key_On;

    [Header("Line")]
    public GameObject PlayerControllorLine;
    public GameObject VRSystemLine;
    public GameObject KeyLine;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        AppCs();
    }

    void AppCs()
    {
        // PlayerControllor_cs
        if (isPlayerControllor_cs)
        {
            PlayerControllor_cs.SetActive(true);
            PlayerControllor_On.SetActive(true);

            PlayerControllor_Off.SetActive(false);

            // Line
            PlayerControllorLine.SetActive(true);
        }
        else
        {
            PlayerControllor_cs.SetActive(false);
            PlayerControllor_On.SetActive(false);

            PlayerControllor_Off.SetActive(true);

            // Line
            PlayerControllorLine.SetActive(false);

        }

        // VRSystem_cs
        if (isVRSystem_cs)
        {
            VRSystem_cs.SetActive(true);
            VRSystem_On.SetActive(true);

            VRSystem_Off.SetActive(false);

            // Line
            VRSystemLine.SetActive(true);
        }
        else
        {
            VRSystem_cs.SetActive(false);
            VRSystem_On.SetActive(false);

            VRSystem_Off.SetActive(true);

            // Line
            VRSystemLine.SetActive(false);
        }

        // Key_cs
        if (isKey_cs)
        {
            Key_cs.SetActive(true);
            Key_On.SetActive(true);

            Key_Off.SetActive(false);

            // Line
            KeyLine.SetActive(true);
        }
        else
        {
            Key_cs.SetActive(false);
            Key_On.SetActive(false);

            Key_Off.SetActive(true);

            // Line
            KeyLine.SetActive(false);
        }
    }

    public void PlayerControllorApp()
    {
        isPlayerControllor_cs = true;
        isVRSystem_cs = false;
        isKey_cs = false;
    }

    public void VRSystemApp()
    {
        isPlayerControllor_cs = false;
        isVRSystem_cs = true;
        isKey_cs = false;
    }

    public void KeyApp()
    {
        isPlayerControllor_cs = false;
        isVRSystem_cs = false;
        isKey_cs = true;
    }
}
