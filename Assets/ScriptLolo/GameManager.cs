using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int score = 0;
    private float gameDuration = 60f;
    private float timeRemaining;
    private bool gameRunning = true;

    void Start()
    {
        timeRemaining = gameDuration;
    }

    void Update()
    {
        if (!gameRunning) return;

        timeRemaining -= Time.deltaTime;
        if (timeRemaining <= 0) EndGame();
    }

    public void AddScore(int amount)
    {
        score += amount;
        EventManager.Instance.ScoreChanged(score); // avisar a todos
    }

    void EndGame()
    {
        gameRunning = false;
        EventManager.Instance.GameOver();
    }
}