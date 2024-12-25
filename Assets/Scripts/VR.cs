using UnityEngine;

public class ToggleGameObjects : MonoBehaviour
{
    public GameObject[] gameObjects;

    private bool isActive = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            isActive = !isActive;

            foreach (GameObject obj in gameObjects)
            {
                obj.SetActive(isActive);
            }
        }
    }
}
