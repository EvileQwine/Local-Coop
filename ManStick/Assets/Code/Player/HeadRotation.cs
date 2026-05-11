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
    Vector2 controllerDir;
    float targetAngle;
    Vector2 mouseDir;
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
        controllerDir = value.Get<Vector2>();
    }

    void OnAttack()
    {
        if (canShoot)
        {
            GameObject playerBullet = Instantiate(Bullet, Gun.transform.position, Gun.transform.rotation);
            if (!controllerActive)
            {
                if (playerBullet != null)
                {
                    playerBullet.GetComponent<Rigidbody2D>().AddForce(mouseDir.normalized * (bulletSpeed), ForceMode2D.Impulse);
                    rbHead.AddForce(-(mouseDir.normalized * bulletSpeed), ForceMode2D.Impulse);
                }
                StartCoroutine(AttackCooldown(attackCooldown));
            }
            else if (controllerDir != Vector2.zero)
            {
                if (playerBullet != null)
                {
                    playerBullet.GetComponent<Rigidbody2D>().AddForce(controllerDir.normalized * (bulletSpeed), ForceMode2D.Impulse);
                    rbHead.AddForce(-(controllerDir.normalized * bulletSpeed), ForceMode2D.Impulse);
                }
                StartCoroutine(AttackCooldown(attackCooldown));
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (controllerDir != Vector2.zero)
        {
            controllerActive = true;
            targetAngle = Mathf.Atan2(controllerDir.y, controllerDir.x) * Mathf.Rad2Deg;
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

            mouseDir = new Vector2(mousePosistion.x - rbHead.position.x, mousePosistion.y - rbHead.position.y);

            targetAngle = Mathf.Atan2(mouseDir.y, mouseDir.x) * Mathf.Rad2Deg;

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