using UnityEngine;

public class HealthScript : MonoBehaviour
{
    public float startHealth = 5;
    public float currHealth;

    void Start()
    {
        currHealth = startHealth;
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
