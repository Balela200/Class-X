using UnityEngine;
using TMPro; // Make sure to include this namespace for TextMeshPro

public class ToggleGameObjects : MonoBehaviour
{
    public GameObject[] gameObjects; // Array of GameObjects to toggle
    public TMP_InputField textField; // Reference to the TMP Input Field

    private bool isActive = false;

    void Update()
    {
        // Check if the 1 key is pressed
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            // Only toggle if the text in the input field is "isActive"
            if (textField.text == "isActive")
            {
                isActive = !isActive;

                foreach (GameObject obj in gameObjects)
                {
                    obj.SetActive(isActive);
                }
            }
        }
    }
}
