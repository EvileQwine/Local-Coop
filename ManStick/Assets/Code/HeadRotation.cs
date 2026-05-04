using System.Drawing;
using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
public class HeadRotation : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 Dircetion;
    float targetAngle;
    Vector2 direction;
    float rotationSpeed = 100;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

   
    void OnLook(InputValue value)
    {
        Dircetion = value.Get<Vector2>();
        Debug.Log("Test");
    }
    void OnJump(InputValue value)
    {
        Debug.Log("Test");
    }
    // Update is called once per frame
    void Update()
    {
        if (Dircetion != Vector2.zero)
        {
            targetAngle = Mathf.Atan2(Dircetion.y, Dircetion.x) * Mathf.Rad2Deg;
        }

    }

    void FixedUpdate()
    {

        //direction = new Vector2(Dircetion.x - rb.position.x, Dircetion.y - rb.position.y);

        float rotation = Mathf.MoveTowardsAngle(rb.rotation, targetAngle - 90, rotationSpeed * Time.fixedDeltaTime);

        rb.MoveRotation(rotation);
    }




}