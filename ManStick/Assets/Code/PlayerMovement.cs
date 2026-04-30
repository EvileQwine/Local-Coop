using System.Collections;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 moveInput;
    [SerializeField] int moveSpeed = 2;
    [SerializeField] int jumpHeight = 6;
    [SerializeField] int dashStrength = 10;
    [SerializeField] int teleportStrength = 10;
    [SerializeField] public enum JumpAbility
    {
        Base,
        Dash,
        Teleport,
    }
    bool isDashing = false;
    public JumpAbility jumpAbility;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (!isDashing)
        {
            rb.linearVelocity = new Vector2(moveInput.x * moveSpeed, rb.linearVelocityY);
        }
    }
    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }
    void OnJump()
    {
        rb.linearVelocityY = 0;
        switch (jumpAbility)
        {
            case JumpAbility.Base:
                rb.linearVelocity = new Vector2(rb.linearVelocity.x * 1, rb.linearVelocity.y * 0);
                rb.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
                break;
            case JumpAbility.Dash:
                rb.linearVelocity = new Vector2(rb.linearVelocity.x * 0, rb.linearVelocity.y * 0);
                if (moveInput.x == 0 && moveInput.y == 0)
                {
                    rb.AddForce(Vector2.up * dashStrength, ForceMode2D.Impulse);
                }
                else
                {
                    Dashing();
                }
                break;
            case JumpAbility.Teleport:
                rb.position = (rb.position + moveInput * teleportStrength);
                break;
        }
    }
    IEnumerator Dashing()
    {
        isDashing = true;
        if (moveInput.x > 0)
        {
            rb.AddForce(Vector2.right * dashStrength, ForceMode2D.Impulse);
        }
        else if (moveInput.x < 0)
        {
            rb.AddForce(Vector2.left * -dashStrength, ForceMode2D.Impulse);
        }
        yield return new WaitForSeconds(0.5f);
        isDashing = false;
    }
}
