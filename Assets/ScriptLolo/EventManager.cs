using System;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // EVENTOS PÚBLICOS
    public event Action<int> OnScoreChanged;
    public event Action OnBalloonHit;
    public event Action OnGameOver;

    // MÉTODOS PARA DISPARAR EVENTOS
    public void BalloonHit()
    {
        OnBalloonHit?.Invoke();
    }

    public void ScoreChanged(int newScore)
    {
        OnScoreChanged?.Invoke(newScore);
    }

    public void GameOver()
    {
        OnGameOver?.Invoke();
    }
}