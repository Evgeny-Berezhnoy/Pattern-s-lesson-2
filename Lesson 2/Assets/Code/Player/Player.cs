using UnityEngine;

public class Player
{
    internal float _speed;
    internal Health _hp;
    internal readonly Transform _transformPlayer;

    public Player(Transform transformPlayer, float speed, Health hp)
    {
        _transformPlayer = transformPlayer;
        _speed = speed;
        _hp = hp;
    }
}