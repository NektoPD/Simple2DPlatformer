using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    private const string JumpComponentName = "Jump";
    private const string SpeedComponentName = "Speed";

    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;
    private Rigidbody2D _playerRB;

    public bool isRunning { get; private set; }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _playerRB = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        HandleInput();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void HandleInput()
    {
        float horizontalMove = Input.GetAxis("Horizontal");

        if (horizontalMove > 0)
        {
            _spriteRenderer.flipX = false;
            ActivateRunAnimation(Mathf.Abs(horizontalMove));
        }
        else if (horizontalMove < 0)
        {
            _spriteRenderer.flipX = true;
            ActivateRunAnimation(Mathf.Abs(horizontalMove));
        }
        else
        {
            ActivateRunAnimation(0);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    private void Move()
    {
        float horizontalMove = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(horizontalMove * _speed, _playerRB.velocity.y);
        _playerRB.velocity = movement;
    }

    private void Jump()
    {
        if (Mathf.Approximately(_playerRB.velocity.y, 0))
        {
            _playerRB.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            ActivateJumpingAnimation();
        }
    }

    private void ActivateRunAnimation(float speed)
    {
        _animator.SetFloat(SpeedComponentName, speed);
    }

    private void ActivateJumpingAnimation()
    {
        _animator.SetTrigger(JumpComponentName);
    }
}
