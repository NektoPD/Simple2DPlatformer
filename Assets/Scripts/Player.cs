using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _playerRB;
    private PlayerAnimator _playerAnimator;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _playerRB = GetComponent<Rigidbody2D>();
        _playerAnimator = GetComponent<PlayerAnimator>();
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
           _playerAnimator.ActivateRunAnimation(Mathf.Abs(horizontalMove));
        }
        else if (horizontalMove < 0)
        {
            _spriteRenderer.flipX = true;
            _playerAnimator.ActivateRunAnimation(Mathf.Abs(horizontalMove));
        }
        else
        {
           _playerAnimator.ActivateRunAnimation(0);
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
            _playerAnimator.ActivateJumpingAnimation();
        }
    }
}
