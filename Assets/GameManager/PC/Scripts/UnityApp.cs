using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UnityApp : MonoBehaviour
{
    [Header("Inspector")]
    public GameObject Player_Inspector;
    public GameObject VRSystem_Inspector;
    public GameObject Key_Inspector;

    bool isPlayer_Inspector;
    bool isVRSystem_Inspector;
    bool isKey_Inspector;

    [Header("Prefab")]
    public GameObject key;

    [Header("Add")]
    public GameObject AddRigidbodyInspector;
    public GameObject Search;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        InspectorUnity();
    }

    public void InspectorUnity()
    {
        // Player Controllor
        if (isPlayer_Inspector)
        {
            Player_Inspector.SetActive(true);
            VRSystem_Inspector.SetActive(false);
            Key_Inspector.SetActive(false);
        }
        else
        {
            Player_Inspector.SetActive(false);
        }

        // VRSystem
        if (isVRSystem_Inspector)
        {
            Player_Inspector.SetActive(false);
            VRSystem_Inspector.SetActive(true);
            Key_Inspector.SetActive(false);
        }
        else
        {
            VRSystem_Inspector.SetActive(false);
        }

        // Key
        if (isKey_Inspector)
        {
            Player_Inspector.SetActive(false);
            VRSystem_Inspector.SetActive(false);
            Key_Inspector.SetActive(true);
        }
        else
        {
            Key_Inspector.SetActive(false);
        }
    }

    public void PlayerInspector()
    {
        isPlayer_Inspector = true;
        isVRSystem_Inspector = false;
        isKey_Inspector = false;
    }

    public void VRInspector()
    {
        isPlayer_Inspector = false;
        isVRSystem_Inspector = true;
        isKey_Inspector = false;
    }

    public void KeyInspector()
    {
        isPlayer_Inspector = false;
        isVRSystem_Inspector = false;
        isKey_Inspector = true;
    }

    public void AddRigidbody()
    {
        if(isKey_Inspector)
        {
            AddRigidbodyInspector.SetActive(true);

            key.GetComponent<Rigidbody>().isKinematic = false;

            Search.SetActive(false);
        }
    }

    public void AddComponent()
    {
        Search.SetActive(true);
    }
}
