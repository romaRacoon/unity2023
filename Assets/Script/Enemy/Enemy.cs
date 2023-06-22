using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int _damage = 25;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            player.TakeDamage(_damage);
        }
    }
}
