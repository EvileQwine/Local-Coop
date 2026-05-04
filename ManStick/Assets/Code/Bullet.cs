using UnityEngine;

public class Bullet : MonoBehaviour
{
    HealthScript healthScript;
    Collider2D collider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        collider = GetComponent<Collider2D>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<HealthScript>() != null)
        {
            collision.gameObject.GetComponent<HealthScript>().Hit(1);
        }
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
