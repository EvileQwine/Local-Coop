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
    [SerializeField] bool vanishOnContact = true;
    [SerializeField] bool vanishOverTime = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        c = GetComponent<Collider2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Body Part"))
        {
            collision.gameObject.GetComponentInParent<HealthScript>().Hit(1);
            Destroy(gameObject);
        }
        if (collision.gameObject.GetComponent<ChainHealth>() != null)
        {
            collision.gameObject.GetComponent<ChainHealth>().Hit(1);
            Destroy(gameObject);
        }
        if (collision.gameObject.GetComponent<AntonHealth>() != null)
        {
            collision.gameObject.GetComponent<AntonHealth>().Hit(1);
            Destroy(gameObject);
        }
        if (vanishOnContact)
        {
            Destroy(gameObject);
        }
        StartCoroutine(BulletTime());
    }
    void Update()
    {

    }
    IEnumerator BulletTime()
    {
        yield return new WaitForSeconds(bulletDespawnTime);
        Destroy(gameObject);
    }
}