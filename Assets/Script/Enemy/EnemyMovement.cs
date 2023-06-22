using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Transform[] _patrolPoints;

    private SpriteRenderer _spriteRenderer;
    private float _speed = 2f;

    private int _currentPointIndex = 0;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, _patrolPoints[_currentPointIndex].position, _speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, _patrolPoints[_currentPointIndex].position) < 0.3f)
        {
            _currentPointIndex = (_currentPointIndex + 1) % _patrolPoints.Length;
            if(_currentPointIndex == 1)
            {
                _spriteRenderer.flipX = false;
            }
            else
            {
                _spriteRenderer.flipX = true;
            }
        }
    }
}
