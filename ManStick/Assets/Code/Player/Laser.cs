using UnityEngine;

public class Laser : MonoBehaviour
{
    private bool hasLineOfSight = false;
    public Transform linecastEndPos;
    void Start()
    {

    }
    void Update()
    {
        RaycastHit2D ray = Physics2D.Linecast(transform.position, linecastEndPos.position);

        if (ray.collider != null)
        {
            hasLineOfSight = ray.collider.CompareTag("Body Part");
            hasLineOfSight = ray.collider.CompareTag("Bullets");
            Debug.Log("I SEE YOU");
            if (hasLineOfSight)
            {
                Debug.DrawLine(transform.position, linecastEndPos.position, Color.magenta);
            }
            else
            {
                Debug.DrawLine(transform.position, linecastEndPos.position, Color.white);
            }
        }
        hasLineOfSight = false;
    }
}
