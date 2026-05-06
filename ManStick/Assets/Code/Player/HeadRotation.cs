using System.Drawing;
using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using Unity.Mathematics;
using System.Collections;
public class HeadRotation : MonoBehaviour
{
    Vector2 Dircetion;
    float targetAngle;
    Vector2 direction;
    Vector2 mousePosistion;
    Rigidbody2D rbHead;
    [SerializeField] GameObject Head;
    [SerializeField] GameObject Gun;
    [SerializeField] GameObject Bullet;
    [SerializeField] float bulletSpeed = 1.0f;

    [SerializeField] float attackCooldown = 0.4f;
    [SerializeField] bool canShoot = true;
    
    bool controllerActive = false;
    bool eyeSide = false;
    float rotationSpeed = 1000000;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rbHead = Head.GetComponent<Rigidbody2D>();
    }

   
    void OnLook(InputValue value)
    {
        Dircetion = value.Get<Vector2>();
    }

    void OnAttack()
    {
        if (canShoot)
        {
            Rigidbody2D playerBullet = Instantiate(Bullet, Gun.transform.position, Gun.transform.rotation).GetComponent<Rigidbody2D>();
            if (!controllerActive)
            {
                playerBullet.AddForce(direction.normalized * (bulletSpeed), ForceMode2D.Impulse);
                rbHead.AddForce(-(direction.normalized * bulletSpeed), ForceMode2D.Impulse);
                StartCoroutine(AttackCooldown(attackCooldown));
            }
            else if (Dircetion != Vector2.zero)
            {
                playerBullet.AddForce(Dircetion.normalized * (bulletSpeed), ForceMode2D.Impulse);
                rbHead.AddForce(-(Dircetion.normalized * bulletSpeed), ForceMode2D.Impulse);
                StartCoroutine(AttackCooldown(attackCooldown));
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (rbHead == null) return;

        if (Dircetion != Vector2.zero)
        {
            controllerActive = true;
            targetAngle = Mathf.Atan2(Dircetion.y, Dircetion.x) * Mathf.Rad2Deg;
        }
        if (rbHead.rotation <= 0 && eyeSide)
        {
            eyeSide = false;
            rbHead.transform.localScale = new Vector2((-rbHead.transform.localScale.x), rbHead.transform.localScale.y);
        }
        else if (rbHead.rotation >= 0 && !eyeSide)
        {
            eyeSide = true;
            rbHead.transform.localScale = new Vector2((-rbHead.transform.localScale.x), rbHead.transform.localScale.y);
        }
        if (rbHead.rotation > 180)
        {
            rbHead.rotation = -180;
        }
        else if (rbHead.rotation < -180)
        {
            rbHead.rotation = 180;
        }
    }

    void FixedUpdate()
    {
        if (!controllerActive)
        {
            mousePosistion = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

            direction = new Vector2(mousePosistion.x - rbHead.position.x, mousePosistion.y - rbHead.position.y);

            targetAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        }
        float rotation = Mathf.MoveTowardsAngle(rbHead.rotation, targetAngle - 90, rotationSpeed * Time.fixedDeltaTime);

        rbHead.MoveRotation(rotation);
    }
    IEnumerator AttackCooldown(float f)
    {
        canShoot = false;
        yield return new WaitForSeconds(f);
        canShoot = true;
    }
}