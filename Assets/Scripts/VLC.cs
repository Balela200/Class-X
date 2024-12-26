using UnityEngine;
using UnityEngine.UI;

public class ObjectSwitcher : MonoBehaviour
{
    [Header("Objects to Switch")]
    public GameObject object1;
    public GameObject object2;

    private Button button1;
    private Button button2;

    void Start()
    {
        if (object1 == null || object2 == null)
        {
            Debug.LogError("Please assign both objects in the inspector.");
            return;
        }

        // Get Button components from each object
        button1 = object1.GetComponentInChildren<Button>();
        button2 = object2.GetComponentInChildren<Button>();

        if (button1 == null || button2 == null)
        {
            Debug.LogError("One of the objects does not have a Button component.");
            return;
            
        }

        // Add listeners to the buttons
        button1.onClick.AddListener(() => SwitchToObject(object2));
        button2.onClick.AddListener(() => SwitchToObject(object1));

        // Ensure only one object is active at the start
        object1.SetActive(true);
        object2.SetActive(false);
    }

    private void SwitchToObject(GameObject targetObject)
    {
        object1.SetActive(targetObject == object1);
        object2.SetActive(targetObject == object2);
    }
}
