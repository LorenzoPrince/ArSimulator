using TMPro;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;

    void Awake()
    {
        scoreText.text = "Puntaje: " + 0; 
    }

    void OnEnable()
    {
        EventManager.Instance.OnScoreChanged += UpdateScore;
    }

    void OnDisable()
    {
        EventManager.Instance.OnScoreChanged -= UpdateScore;
    }

    void UpdateScore(int newScore)
    {
        if (scoreText != null)
            scoreText.text = "Puntaje: " + newScore;
    }
}