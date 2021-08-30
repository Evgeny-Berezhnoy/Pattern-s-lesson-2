using UnityEngine;

public class Player
{
    private float _speed;
    private float _hp;
    private readonly Transform _transformPlayer;
    public Transform TransformPlayer => _transformPlayer;
    public float Hp { get => _hp; set => _hp = value; }
    public float Speed {get => _speed; set => _speed = value; }
    public Player(Transform transformPlayer, float speed, float hp)
    {
        _transformPlayer = transformPlayer;
        _speed = speed;
        _hp = hp;
    }
}
