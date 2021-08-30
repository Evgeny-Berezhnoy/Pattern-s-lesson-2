using UnityEngine;

public class PlayerController : IMove
    {
        private readonly Transform _transform;
        private Rigidbody2D _rigidbody2D;

        public PlayerController(Player player, Rigidbody2D rigidbody2D)
        {
            _transform = player.TransformPlayer;
            _rigidbody2D = rigidbody2D;
            Speed = player.Speed;
        }
        public float Speed { get; }
        public void Move(float horizontal, float vertical, float deltaTime)
        {
           var speed = deltaTime * Speed;
           Vector3 move = new Vector3(horizontal,0, vertical);
           _rigidbody2D.AddForce( move * speed);
        }
    }
