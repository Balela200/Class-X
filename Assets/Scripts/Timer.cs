using UnityEngine;
using TMPro; // Import TextMeshPro namespace
using UnityEngine.SceneManagement; // For scene management

public class CountdownTimer : MonoBehaviour
{
    public TMP_Text timerText; // Reference to your TextMeshPro text
    public float timeRemaining = 180f; // 3 minutes in seconds

    private bool isCountingDown = true;

    void Update()
    {
        if (isCountingDown)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                UpdateTimerDisplay();
            }
            else
            {
                isCountingDown = false;
                timeRemaining = 0;
                UpdateTimerDisplay();
                LoadLoseScene();
            }
        }
    }

    void UpdateTimerDisplay()
    {
        // Convert time to minutes and seconds
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);

        // Update the TextMeshPro text
        timerText.text = $"{minutes:00}:{seconds:00}";
    }

    void LoadLoseScene()
    {
        // Replace "Lose" with the name of your Lose scene
        SceneManager.LoadScene("Lose");
        Cursor.lockState = CursorLockMode.None;
    }
}
