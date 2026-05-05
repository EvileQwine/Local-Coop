using UnityEngine;

public class CheckGround : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Rigidbody2D rb;
    [SerializeField] ContactFilter2D groundFilter;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
    }
    void Update()
    {
        if (rb.IsTouching(groundFilter))
        {
            GetComponentInParent<PlayerMovement>().footOnGround = true;
        }
        else
        {
            GetComponentInParent<PlayerMovement>().footOnGround = false;
        }
    }
}
