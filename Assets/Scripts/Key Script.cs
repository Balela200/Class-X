using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; // Required for TextMeshPro

public class PlayerController : MonoBehaviour
{
    [SerializeField] private string keyTag = "Key"; // Default value
    [SerializeField] private string doorTag = "Door"; // Default value
    [SerializeField] private TMP_InputField keyInputField; // TMP Input Field for Key Tag
    [SerializeField] private TMP_InputField doorInputField; // TMP Input Field for Door Tag
    private bool hasKey = false;

    private void Start()
    {
        // Assign default tags from TMP Input Fields, if assigned in Inspector
        if (keyInputField != null)
        {
            keyTag = keyInputField.text; 
            keyInputField.onValueChanged.AddListener(UpdateKeyTag); // Update keyTag dynamically
        }

        if (doorInputField != null)
        {
            doorTag = doorInputField.text;
            doorInputField.onValueChanged.AddListener(UpdateDoorTag); // Update doorTag dynamically
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider has the Key tag
        if (other.CompareTag(keyTag))
        {
            hasKey = true;
            Destroy(other.gameObject);
            Debug.Log("Key picked up!");
        }

        // Check if the collider has the Door tag and the player has the key
        if (other.CompareTag(doorTag) && hasKey)
        {
            Debug.Log("Door unlocked! Moving to the next scene...");
            SceneManager.LoadScene("Win");
            Cursor.lockState = CursorLockMode.None;
        }
    }

    // Update the Key Tag dynamically
    private void UpdateKeyTag(string newKeyTag)
    {
        keyTag = newKeyTag;
        Debug.Log($"Key tag updated to: {keyTag}");
    }

    // Update the Door Tag dynamically
    private void UpdateDoorTag(string newDoorTag)
    {
        doorTag = newDoorTag;
        Debug.Log($"Door tag updated to: {doorTag}");
    }
}
