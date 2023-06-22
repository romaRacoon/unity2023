using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private float _force = 10f;

    private Transform _transform;
    private bool _isGrounded = false;

    private void Start()
    {
        _transform = GetComponent<Transform>();
    }

    private void Update()
    {
        TryJump();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent(out Ground ground))
        {
            _isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Ground ground))
        {
            _isGrounded = false;
        }
    }

    private void TryJump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            Debug.Log(1);
            _transform.Translate(0, _force, 0);
        }
    }
}
