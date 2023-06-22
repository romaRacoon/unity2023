using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    private const string _idleConst = "idle";

    [SerializeField] private Slider _healthView;
    [SerializeField] private TextMeshProUGUI _coinsView;

    private Animator _animator;
    private int _health = 100;
    private int _coins = 0;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _animator.Play(_idleConst);
        _coinsView.text = _coins.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Coin coin))
        {
            _coins++;
            _coinsView.text = _coins.ToString();
            coin.Destroy();
        }
    }

    public void TakeDamage(int damage)
    {
        if(_health >= 0)
        {
            _health -= damage;
            _healthView.value = _health;

            if(_health <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
}
