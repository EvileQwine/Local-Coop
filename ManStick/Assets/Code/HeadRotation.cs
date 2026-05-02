using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class HeadRotation : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 Dircetion;
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
        
        Vector2 direction = new Vector2( Dircetion.x - transform.position.x, Dircetion.y - transform.position.y);

        Vector2 teast = Dircetion;
        transform.up = teast;
    }


    
}