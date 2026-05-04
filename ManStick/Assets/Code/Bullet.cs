using System.Collections;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine.InputSystem;

public class Bullet : MonoBehaviour
{
    HealthScript healthScript;
    Collider2D collider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        collider = GetComponent<Collider2D>();
        collider.enabled = false;
        StartCoroutine(Collider());
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
    IEnumerator Collider()
    {
        yield return new WaitForSeconds(0.2f);
        collider.enabled = true;
    }
}