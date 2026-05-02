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
    [SerializeField] bool canMove = false;
    public JumpAbility jumpAbility;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (canMove)
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
                rb.linearVelocity = Vector2.zero;
                if (moveInput == Vector2.zero)
                {
                    rb.AddForce(Vector2.up * dashStrength, ForceMode2D.Impulse);
                }
                else 
                {
                    rb.AddForce(moveInput * dashStrength, ForceMode2D.Impulse);
                    StartCoroutine(DisableMovement(0.3f));
                }
                break;
            case JumpAbility.Teleport:
                rb.position = (rb.position + (moveInput * teleportStrength));
                break;
        }
    }
    IEnumerator DisableMovement(float f)
    {
        canMove = false;
        yield return new WaitForSeconds(f);
        canMove = true;
    }
}
