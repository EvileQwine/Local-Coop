using System.Drawing;
using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using Unity.Mathematics;
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
    bool controllerActive = false;
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
        Rigidbody2D playerBullet = Instantiate(Bullet, Gun.transform.position, Gun.transform.rotation).GetComponent<Rigidbody2D>();
        if (!controllerActive)
        {
            playerBullet.AddForce(direction.normalized * (bulletSpeed), ForceMode2D.Impulse);
            rbHead.AddForce(-(direction.normalized * bulletSpeed), ForceMode2D.Impulse);
        }
        else if (Dircetion != Vector2.zero)
        {
            playerBullet.AddForce(Dircetion.normalized * (bulletSpeed), ForceMode2D.Impulse);
            rbHead.AddForce(-(Dircetion.normalized * bulletSpeed), ForceMode2D.Impulse);
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (Dircetion != Vector2.zero)
        {
            controllerActive = true;
            targetAngle = Mathf.Atan2(Dircetion.y, Dircetion.x) * Mathf.Rad2Deg;
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




}