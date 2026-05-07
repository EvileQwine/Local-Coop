using UnityEngine;

public class AntonHealth : MonoBehaviour
{
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
    }
    public void Hit(int amount)
    {
        currHealth -= amount;
    }
}
