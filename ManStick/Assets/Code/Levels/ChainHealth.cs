using UnityEngine;

public class ChainHealth : MonoBehaviour
{
    float maxChainHealth = 5;
    float currChainHealth;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currChainHealth = maxChainHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (currChainHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void Hit(int amount)
    {
        currChainHealth -= amount;
    }
}
