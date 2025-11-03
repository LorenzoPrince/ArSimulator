using UnityEngine;

public class BalloonScript : MonoBehaviour
{
    public int points = 1;
    public GameObject popEffect;
    public float lifetime = 20f;
    public float floatSpeed = 0.2f;

    private void Start()
    {
        Destroy(gameObject, lifetime);
    }

    private void Update()
    {
        transform.Translate(Vector3.up * floatSpeed * Time.deltaTime);
    }

    public void Hit()
    {
        if (popEffect != null)
        {
            Instantiate(popEffect, transform.position, Quaternion.identity);  // Crear el efecto de "pop"
        }

        EventManager.Instance.BalloonHit(points);  // Notificar al EventManager que el globo ha sido destruido

        Destroy(gameObject);  // Eliminar el globo del juego
    }

}