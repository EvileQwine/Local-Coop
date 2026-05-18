using System.Collections;
using UnityEngine;

public class RaycastBolt : MonoBehaviour
{
    private bool hasLineOfSight = false;
    private bool canShoot = true;
    public Transform linecastEndPos;
    public Transform bolt;
    [SerializeField] private float shootCooldown = 5f;
    [SerializeField] private float shootSpeed = 5f;
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
            else { hasLineOfSight = false; }
            if (hasLineOfSight && canShoot)
            {
                StartCoroutine(Shoot());
            }
        }
    }

    private IEnumerator Shoot()
    {
        hasLineOfSight = false;
        canShoot = false;

        Rigidbody2D shootyBolt = Instantiate(bolt, transform.position, transform.rotation.normalized).GetComponent<Rigidbody2D>();
        shootyBolt.AddForce(transform.up * shootSpeed, ForceMode2D.Impulse);

        yield return new WaitForSeconds(shootCooldown);
        canShoot = true;
    }
}
