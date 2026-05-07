using System.Collections;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine.InputSystem;

public class Bullet : MonoBehaviour
{
    HealthScript healthScript;
    Collider2D c;
    [SerializeField] float bulletDespawnTime = 2.5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        c = GetComponent<Collider2D>();
        c.enabled = false;
        StartCoroutine(Collider());
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<HealthScript>() != null)
        {
            collision.gameObject.GetComponent<HealthScript>().Hit(1);
        }
        if (collision.gameObject.GetComponent<AntonHealth>() != null)
        {
            collision.gameObject.GetComponent<AntonHealth>().Hit(1);
        }
        StartCoroutine(BulletTime());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<ChainHealth>() != null)
        {
            collision.gameObject.GetComponent<ChainHealth>().Hit(1);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator Collider()
    {
        yield return new WaitForSeconds(0.2f);
        c.enabled = true;
    }

    IEnumerator BulletTime()
    {
        yield return new WaitForSeconds(bulletDespawnTime);
        Destroy(gameObject);
    }
}