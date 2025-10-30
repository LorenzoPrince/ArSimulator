using UnityEngine;

public class ShootScript : MonoBehaviour
{
    public GameObject arCamera;
    public GameObject smoke;

    public void Shoot()
    {
        Debug.Log("Shoot() llamado!");
        RaycastHit hit;


        if (Physics.Raycast(arCamera.transform.position, arCamera.transform.forward, out hit))
        {
            Debug.Log("Hit: " + hit.transform.name);

            if (hit.transform.CompareTag("Balloon"))
            {
                // Llamar al globo para que se destruya y dispare sus eventos
                BalloonScript balloon = hit.transform.GetComponent<BalloonScript>();
                if (balloon != null)
                    balloon.Hit();

                // Instanciar efecto de humo
                if (smoke != null)
                    Instantiate(smoke, hit.point, Quaternion.LookRotation(hit.normal));
            }
        }
    }
}
