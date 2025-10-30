using UnityEngine;

public class ShootScript : MonoBehaviour
{
    public GameObject arcamera;
    public GameObject smoke;

    public void shoot()
    {
        RaycastHit hit;
        Debug.DrawRay(arcamera.transform.position, arcamera.transform.forward * 10f, Color.red, 1f);
        if (Physics.Raycast(arcamera.transform.position, arcamera.transform.forward, out hit))
        {
            Debug.Log("Hit: " + hit.transform.name);
            if (hit.transform.CompareTag("Balloon"))
            {
                Destroy(hit.transform.gameObject);
                Instantiate(smoke, hit.point, Quaternion.LookRotation(hit.normal));
                GameManager.score += 10;
            }
        }
    }

}
