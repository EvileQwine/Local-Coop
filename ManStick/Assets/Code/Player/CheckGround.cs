using UnityEngine;

public class CheckGround : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Rigidbody2D rb;
    [SerializeField] bool isLeg = true;
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
        if (isLeg)
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
        else
        {
            if (rb.IsTouching(groundFilter))
            {
                GetComponentInParent<PlayerMovement>().armOnGround = true;
            }
            else
            {
                GetComponentInParent<PlayerMovement>().armOnGround = false;
            }
        }
    }
}
