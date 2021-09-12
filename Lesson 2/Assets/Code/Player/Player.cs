using UnityEngine;

public class Player
{
    internal float _speed;
    internal float _hp;
    internal readonly Transform _transformPlayer;

    public Player(Transform transformPlayer, float speed, float hp)
    {
        _transformPlayer = transformPlayer;
        _speed = speed;
        _hp = hp;
    }
}