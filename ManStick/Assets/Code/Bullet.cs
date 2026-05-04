using UnityEngine;

public class Bullet : MonoBehaviour
{
    HealthScript healthScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        healthScript = GetComponent<HealthScript>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        healthScript.Hit(1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
