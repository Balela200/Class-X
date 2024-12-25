using UnityEngine;

public class ToggleGameObjects : MonoBehaviour
{
    // Array to hold the GameObjects you want to toggle
    public GameObject[] gameObjects;

    // To keep track of the toggle state (on/off)
    private bool isActive = false;

    void Update()
    {
        // Check if the 1 key is pressed
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            // Toggle the state of each GameObject
            isActive = !isActive;

            // Loop through all GameObjects and toggle their active state
            foreach (GameObject obj in gameObjects)
            {
                obj.SetActive(isActive);
            }
        }
    }
}
