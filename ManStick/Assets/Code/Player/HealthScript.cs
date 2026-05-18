using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    public Slider healthbarSlider;
    public float maxHealth = 10;
    public float currHealth;
    private float lavaUpForce = 100f;
    private float lavaDamageCooldown = 2f;
    private bool hit = false;
    Rigidbody2D[] rb;
    HingeJoint2D[] hingeJoints;

    void Start()
    {
        currHealth = maxHealth;
        rb = GetComponentsInChildren<Rigidbody2D>();
        hingeJoints = GetComponentsInChildren<HingeJoint2D>();
    }

    private void Update()
    {
        if (currHealth <= 0)
        {
            for(int i  = 0; i < hingeJoints.Length; i++)
            {
                Destroy(hingeJoints[i]);
            }
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

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Lava"))
        {
            if (!hit)
            {
                Hit(1);
                for (int i = 0; i < rb.Length; i++)
                {
                    rb[i].AddForce(Vector2.up * lavaUpForce, ForceMode2D.Impulse);
                }
                StartCoroutine(LavaDamageCooldown());
            }
        }
    }

    IEnumerator LavaDamageCooldown()
    {
        hit = true;
        yield return new WaitForSeconds(lavaDamageCooldown);
        hit = false;
    }
}
