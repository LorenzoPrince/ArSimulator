using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int score = 0;
    private float gameDuration = 60f;
    private float timeRemaining;
    private bool gameRunning = true;

    private void OnEnable()
    {
        if (EventManager.Instance != null)
            EventManager.Instance.OnBalloonHit += OnBalloonHit;
    }

    private void OnDisable()
    {
        if (EventManager.Instance != null)
            EventManager.Instance.OnBalloonHit -= OnBalloonHit;
    }

    private void Start()
    {
        timeRemaining = gameDuration;
    }

    private void Update()
    {
        if (!gameRunning)
            return;

        timeRemaining -= Time.deltaTime;
        if (timeRemaining <= 0f)
            EndGame();
    }

    private void OnBalloonHit(int points)
    {
        if (!gameRunning)
            return;

        score += points;
        EventManager.Instance.ScoreChanged(score);
    }

    private void EndGame()
    {
        gameRunning = false;
        EventManager.Instance.GameOver();
    }
}