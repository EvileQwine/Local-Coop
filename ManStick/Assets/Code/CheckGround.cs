using UnityEngine;

public class CheckGround : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Rigidbody2D rb;
    bool canPlayerJump;
    [SerializeField] ContactFilter2D groundFilter;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        canPlayerJump = GetComponentInParent<PlayerMovement>().canJump;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.IsTouching(groundFilter) && !canPlayerJump)
            Debug.Log("blej");
        {
            canPlayerJump = true;
        }
    }
}
