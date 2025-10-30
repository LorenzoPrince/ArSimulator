using System;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    // Eventos
    public event Action<int> OnScoreChanged;
    public event Action<int> OnBalloonHit; // ? ahora pasa puntos como parámetro
    public event Action OnGameOver;

    // Métodos para disparar
    public void BalloonHit(int points)
    {
        OnBalloonHit?.Invoke(points); // notifica el puntaje del globo
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