using System.Collections;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 moveInput;
    [SerializeField] int moveSpeed = 10;
    [SerializeField] int jumpHeight = 150;
    [SerializeField] int dashStrength = 150;
    [SerializeField] int teleportStrength = 150;
    [SerializeField] public enum JumpAbility
    {
        Base,
        Dash,
        Teleport,
    }
    [SerializeField] bool canMove = true;
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
        rb.linearVelocity = Vector2.zero;
        switch (jumpAbility)
        {
            case JumpAbility.Base:
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
