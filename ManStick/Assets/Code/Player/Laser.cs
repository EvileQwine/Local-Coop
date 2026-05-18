using System.Collections;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private bool hasLineOfSight = false;
    public Vector3 linecastEndPos;
    LineRenderer lineRenderer;
    [SerializeField] float laserLag = 1f;
    [SerializeField] float flashTime = 0.1f;
    [SerializeField] float laserEndLag = 1.5f;
    bool active = false;
    void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }
    void Start()
    {
        
    }
    public void AssignEndPoint(Vector3 point)
    {
        linecastEndPos = point;
        StartCoroutine(LaserStart());
    }
    void Update()
    {
        if (active)
        {
            RaycastHit2D ray = Physics2D.Linecast(transform.position, linecastEndPos);
            if (ray.collider != null)
            {
                hasLineOfSight = ray.collider.CompareTag("Body Part");
                hasLineOfSight = ray.collider.CompareTag("Bullets");
            }
            else
            {
                hasLineOfSight = false;
            }
        }
    }
    IEnumerator LaserStart()
    {
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, linecastEndPos);
        lineRenderer.startColor = Color.greenYellow;
        lineRenderer.endColor = Color.yellow;
        yield return new WaitForSeconds(laserLag);
        StartCoroutine(Flash());
        lineRenderer.startColor = Color.darkRed;
        lineRenderer.endColor = Color.red;
        active = true;
        yield return new WaitForSeconds(laserEndLag);
        Destroy(gameObject);
    }
    IEnumerator Flash()
    {
        for (int i = 0; i < 5; i++)
        {
            lineRenderer.startColor = Color.greenYellow;
            lineRenderer.endColor = Color.yellow;
            yield return new WaitForSeconds((flashTime/2));
            lineRenderer.startColor = Color.darkRed;
            lineRenderer.endColor = Color.red;
            yield return new WaitForSeconds((flashTime / 2));
        }
    }
}
