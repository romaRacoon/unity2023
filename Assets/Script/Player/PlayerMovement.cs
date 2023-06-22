using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private const string _isRunningConst = "IsRunning";

    [SerializeField] private float _speed = 25f;

    private SpriteRenderer _spriteRenderer;
    private Animator _animator;
    private Rigidbody2D _rb;
    private Vector2 _moveVector;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            if (Input.GetKey(KeyCode.A))
                _spriteRenderer.flipX = true;
            else if(Input.GetKey(KeyCode.D))
                _spriteRenderer.flipX = false;

            _animator.SetBool(_isRunningConst, true);
            _moveVector.x = Input.GetAxis("Horizontal");
            _rb.MovePosition(_rb.position + _moveVector * _speed * Time.deltaTime);
        }
        else
        {
            _animator.SetBool(_isRunningConst, false);
        }
    }
}
