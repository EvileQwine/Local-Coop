using System.Drawing;
using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using Unity.Mathematics;
public class HeadRotation : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 Dircetion;
    float targetAngle;
    Vector2 direction;
    Vector2 mousePosistion;
    bool controllerActive = false;
    float rotationSpeed = 100;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

   
    void OnLook(InputValue value)
    {
        Dircetion = value.Get<Vector2>();
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

            direction = new Vector2(mousePosistion.x - rb.position.x, mousePosistion.y - rb.position.y);

            targetAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        }
        float rotation = Mathf.MoveTowardsAngle(rb.rotation, targetAngle - 90, rotationSpeed * Time.fixedDeltaTime);

        rb.MoveRotation(rotation);
    }




}