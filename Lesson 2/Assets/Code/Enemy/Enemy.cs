using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _damageEnemy;
    private PlayerView _playerView;

    public void DamagePlayer(PlayerView hp, float damage)
    {
        hp.PlayerHP.Current -= damage;
        Debug.Log($"{hp.PlayerHP.Current}");
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        _playerView = other.gameObject.GetComponent<PlayerView>();
        if (_playerView)
        {
            DamagePlayer(_playerView, _damageEnemy);
        }

        if (_playerView.PlayerHP.Current <= 0)
        {
            Destroy(_playerView);
            Debug.LogWarning("GAME OVER");
        }
    }
}
