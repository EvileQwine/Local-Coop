using UnityEngine;

public class Laser : MonoBehaviour
{
    private bool hasLineOfSight = false;
    public Vector3 linecastEndPos;
    LineRenderer lineRenderer;
    void Awake()
    {

    }
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }
    public void AssignEndPoint(Vector3 point)
    {
        linecastEndPos = point;
    }
    void Update()
    {
        RaycastHit2D ray = Physics2D.Linecast(transform.position, linecastEndPos);

        if (ray.collider != null)
        {
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, linecastEndPos);

            hasLineOfSight = ray.collider.CompareTag("Body Part");
            hasLineOfSight = ray.collider.CompareTag("Bullets");
            if (hasLineOfSight)
            {
                Debug.DrawLine(transform.position, linecastEndPos, Color.greenYellow);
            }
            else
            {
                Debug.DrawLine(transform.position, linecastEndPos, Color.white);
            }
        }
        hasLineOfSight = false;
    }
}
