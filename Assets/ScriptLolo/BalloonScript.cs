using UnityEngine;

public class BalloonScript : MonoBehaviour
{
    public int points = 10;
    public GameObject popEffect;
    public float lifetime = 10f;  // tiempo hasta autodestrucción

    private void Start()
    {
        // Destruir automáticamente después de 'lifetime' segundos
        Destroy(gameObject, lifetime);
    }

    public void Hit()
    {
        if (popEffect != null)
            Instantiate(popEffect, transform.position, Quaternion.identity);

        EventManager.Instance.BalloonHit();            // notificar que se golpeó
        EventManager.Instance.ScoreChanged(points);    // sumar puntaje

        Destroy(gameObject); // destruir inmediatamente al golpear
    }
}