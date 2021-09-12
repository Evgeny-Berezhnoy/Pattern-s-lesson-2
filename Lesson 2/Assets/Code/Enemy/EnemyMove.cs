using UnityEngine;

public class EnemyMove : Enemy
{
    [SerializeField] private float _speed;
    [SerializeField] private GameObject obj;
    private PlayerView _playerView;

    private void Start()
    {
        _playerView = FindObjectOfType<PlayerView>();
    }

    public void EnemyAttack()
    {
        var vector = _playerView.transform.position - obj.transform.position;
        transform.Translate(vector * _speed);
    }

    private void FixedUpdate()
    {
        EnemyAttack();
    }
}