using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private bool hasKey = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Key"))
        {
            hasKey = true;
            Destroy(other.gameObject);
            Debug.Log("Key picked up!");
        }

        if (other.CompareTag("Door") && hasKey)
        {
            Debug.Log("Door unlocked! Moving to the next scene...");
            SceneManager.LoadScene("NextScene"); //مهند عدل السين من هنا!!
        }
    }
}
