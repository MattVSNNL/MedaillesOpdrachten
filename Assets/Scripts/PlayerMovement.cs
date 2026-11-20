using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public float movementSpeed = 5f;
    public float jumpPower = 8f;

    [SerializeField] private InputActionAsset inputActions;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private InputActionMap movementMap;
    private InputAction jump, left, right;

    private float horizontal;
    private bool jumpRequest = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();

        movementMap = inputActions.FindActionMap("Movement");

        jump = inputActions.FindAction("Jump");
        left = inputActions.FindAction("Left");
        right = inputActions.FindAction("Right");
    }

    void OnEnable() => movementMap.Enable();
    void OnDisable() => movementMap.Disable();

    // Update is called once per frame
    void Update()
    {
        horizontal = 0;

        if (left.IsPressed())
        {
            horizontal--;
            sr.flipX = true;
        }

        if (right.IsPressed())
        {
            horizontal++;
            sr.flipX = false;
        }

        if (jump.WasPressedThisFrame())
            jumpRequest = true;
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontal * movementSpeed, rb.linearVelocity.y);

        if (jumpRequest && isGrounded())
        {
            rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        }
            

        jumpRequest = false;
    }

    bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.15f, groundLayer) != null;
    }
}
