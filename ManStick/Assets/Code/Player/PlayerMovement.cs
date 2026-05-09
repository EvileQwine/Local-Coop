using System.Collections;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Splines.ExtrusionShapes;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D[] rb;
    Rigidbody2D rbHead;
    Vector2 moveInput;
    [SerializeField] GameObject head;
    [SerializeField] GameObject particle;
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
    [SerializeField] float[] jumpCooldowns = new float[3] { 2, 3, 2 };
    [SerializeField] bool canMove = true;
    [SerializeField] public bool canJump = true;
    public bool footOnGround = false;
    public bool armOnGround = false;
    public JumpAbility jumpAbility;
    void Awake()
    {
        rb = GetComponentsInChildren<Rigidbody2D>();
        rbHead = head.GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (canMove)
        {
            for (int i = 0; i < rb.Length; i++)
            {
                if (rb[i] != null)
                {
                    rb[i].linearVelocity = new Vector2(moveInput.x * moveSpeed, rb[i].linearVelocityY);
                }
            }
        }
        //if (armOnGround && !footOnGround)
        //{
        //    for (int i = 0; i < rb.Length; i++)
        //    {
        //        rb[i].AddForce(Vector2.up * 20, ForceMode2D.Force);
        //    }
        //}
    }
    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }
    void OnJump()
    {
        if (canJump || footOnGround)
        {
            if (canJump && !footOnGround)
            {
                for (int i = 0; i < 12 ; i++)
                {
                    Instantiate(particle, (new Vector3(rbHead.transform.position.x + Random.Range(-2 , 2), (rbHead.transform.position.y - 4) + Random.Range(-1, 1), rbHead.transform.position.z)), Quaternion.identity);
                }
            }
            for (int i = 0; i < rb.Length; i++)
            {
                rb[i].linearVelocity = Vector2.zero;
            }
            switch (jumpAbility)
            {
                case JumpAbility.Base:
                    for (int i = 0; i < rb.Length; i++)
                    {
                        rb[i].AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
                    }
                    StartCoroutine(JumpCooldown(jumpCooldowns[0]));
                    break;
                case JumpAbility.Dash:
                    for (int i = 0; i < rb.Length; i++)
                    {
                        rb[i].linearVelocity = Vector2.zero;
                    }
                    if (moveInput.x == 0 && moveInput.y == 0)
                    {
                        for (int i = 0; i < rb.Length; i++)
                        {
                            rb[i].AddForce(Vector2.up * dashStrength, ForceMode2D.Impulse);
                        }
                    }
                    else
                    {
                        for (int i = 0; i < rb.Length; i++)
                        {
                            rb[i].AddForce(moveInput * dashStrength, ForceMode2D.Impulse);
                        }
                        StartCoroutine(DisableMovement(0.3f));
                    }
                    StartCoroutine(JumpCooldown(jumpCooldowns[1]));
                    break;
                case JumpAbility.Teleport:
                    for (int i = 0; i < rb.Length; i++)
                    {
                        rb[i].position = (rb[i].position + (moveInput * teleportStrength));
                    }
                    StartCoroutine(JumpCooldown(jumpCooldowns[2]));
                    break;
            }
        }
    }
    IEnumerator JumpCooldown(float f)
    {
        canJump = false;
        yield return new WaitForSeconds(f);
        canJump = true;
    }
    IEnumerator DisableMovement(float f)
    {
        canMove = false;
        yield return new WaitForSeconds(f);
        canMove = true;
    }
}
