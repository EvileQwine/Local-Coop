using System.Security.Cryptography;
using UnityEngine;

public class Balancescript : MonoBehaviour
{
    [SerializeField]float targetRoatation = 0;
    Rigidbody2D rb;
    [SerializeField] float force = 100;
    [SerializeField] bool isArm = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.MoveRotation(Mathf.LerpAngle(rb.rotation, targetRoatation, force * Time.fixedDeltaTime));
        if (isArm)
        {
            targetRoatation = Random.Range(0, 360);
        }
    }

}
