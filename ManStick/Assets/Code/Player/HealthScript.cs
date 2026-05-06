using System;
using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    public Slider healthbarSlider;
    public float maxHealth = 5;
    public float currHealth;

    void Start()
    {
        currHealth = maxHealth;
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
}
