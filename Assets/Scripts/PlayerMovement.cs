using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private float MovementSpeed = 5f;
    private float JumpPower = 8f;

    [SerializeField] private InputActionAsset _inputActions;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _groundLayer;

    private Rigidbody2D _rigidBody;
    private SpriteRenderer _spriteRenderer;
    private InputActionMap _movementMap;
    private InputAction _jump, _left, _right;

    private float _horizontal;
    private bool _jumpRequest = false;

    // Update is called once per frame
    void Update()
    {
        _horizontal = 0;

        if (_left.IsPressed())
        {
            Debug.Log("Moving Left");
            _horizontal--;
            _spriteRenderer.flipX = true;
        }

        if (_right.IsPressed())
        {
            Debug.Log("Moving Right");
            _horizontal++;
            _spriteRenderer.flipX = false;
        }

        if (_jump.WasPressedThisFrame())
            _jumpRequest = true;
    }

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();

        _movementMap = _inputActions.FindActionMap("Movement");

        _jump = _inputActions.FindAction("Jump");
        _left = _inputActions.FindAction("Left");
        _right = _inputActions.FindAction("Right");
    }

    private void FixedUpdate()
    {
        _rigidBody.linearVelocity = new Vector2(_horizontal * MovementSpeed, _rigidBody.linearVelocity.y);

        if (_jumpRequest && isGrounded())
        {
            Debug.Log("Jumped");
            _rigidBody.AddForce(Vector2.up * JumpPower, ForceMode2D.Impulse);
        }
        
        _jumpRequest = false;
    }

    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(_groundCheck.position, 0.15f, _groundLayer) != null;
    }

    private void OnEnable() => _movementMap.Enable();
    private void OnDisable() => _movementMap.Disable();


}
