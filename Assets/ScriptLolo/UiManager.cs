using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;

    void Awake()
    {
        scoreText.text = "Puntaje: " + 0; 
    }

    void OnEnable()
    {
        if (EventManager.Instance != null)
            EventManager.Instance.OnScoreChanged += UpdateScore;
        else
            Debug.LogWarning("EventManager.Instance es null en OnEnable (UiManager)");
    }

    void OnDisable()
    {
        if (EventManager.Instance != null)
            EventManager.Instance.OnScoreChanged -= UpdateScore;
    }

    void UpdateScore(int newScore)
    {
        if (scoreText != null)
            scoreText.text = "Puntaje: " + newScore;
    }

    public void Exit()
    {
        SceneManager.LoadScene("Menu");
    }
}