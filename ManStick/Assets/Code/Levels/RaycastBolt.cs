using System.Collections;
using UnityEngine;

public class RaycastBolt : MonoBehaviour
{
    private bool hasLineOfSight = false;
    private bool canShoot = true;
    public Transform linecastEndPos;
    public Transform bolt;
    private float shootCooldown = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D ray = Physics2D.Linecast(transform.position, linecastEndPos.position);

        if (ray.collider != null)
        {
            if (ray.collider.CompareTag("Body Part") || ray.collider.CompareTag("Bullets"))
            {
                hasLineOfSight = true;
            }
            else { hasLineOfSight= false; }
            Debug.Log($"{hasLineOfSight}");
            Debug.Log("I SEE YOU");
            if (hasLineOfSight && canShoot)
            {
                Debug.Log("hit");
                Debug.DrawLine(transform.position, linecastEndPos.position, Color.red);
                StartCoroutine(Shoot());
            }
            else { Debug.DrawLine(transform.position, linecastEndPos.position, Color.blue); }
        }
    }

    private IEnumerator Shoot()
    {
        hasLineOfSight = false; 
        canShoot = false;
        Instantiate(bolt, transform.position, transform.rotation);
        yield return new WaitForSeconds(shootCooldown);
        canShoot = true;
    }
}
