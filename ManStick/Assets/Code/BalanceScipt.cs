using UnityEngine;

public class Balancescript : MonoBehaviour
{
    float targetRoatation = 0;
    Rigidbody2D rb;
    float force = 15;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.MoveRotation(Mathf.LerpAngle(rb.rotation, targetRoatation, force * Time.fixedDeltaTime));
    }

    void OnJump()
    {
        rb.linearVelocityY = 0f;
    }
}
