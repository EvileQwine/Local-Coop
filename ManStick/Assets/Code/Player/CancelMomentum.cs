using UnityEngine;

public class CancelMomentum : MonoBehaviour
{
    Rigidbody2D rb;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    public void OnJump()
    {
        rb.linearVelocity = Vector2.zero;
    }
}
