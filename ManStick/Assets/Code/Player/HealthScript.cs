using System;
using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    public Slider healthbarSlider;
    public float maxHealth = 5;
    public float currHealth;
    private float lavaUpForce = 10;
    Rigidbody2D[] rb;
    private Collider2D[] colliderA;

    void Start()
    {
        currHealth = maxHealth;
        colliderA = GetComponentsInChildren<Collider2D>();
        rb = GetComponentsInChildren<Rigidbody2D>();
    }

    private void Update()
    {
        if (currHealth <= 0)
        {
            Destroy(gameObject);
        }

        healthbarSlider.value = currHealth;
        healthbarSlider.maxValue = maxHealth;
    }

    public void Hit(int amount)
    {
        currHealth -= amount;
    }

    public void Heal(int amount)
    {
        currHealth += amount;
    }
    private void TouchLava()
    {
        Debug.Log("Hit lava");
        currHealth--;
        for (int i = 0; i < rb.Length; i++)
        {
            rb[i].AddForce(Vector2.up * lavaUpForce, ForceMode2D.Impulse);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collision");
        for (int p = 0; p < colliderA.Length; p++)
        {
            if (collision.gameObject.CompareTag("Lava"))
            {
                TouchLava();
            }
        }
    }
}
