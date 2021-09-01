using UnityEngine;

public class PlayerController : IMove
    {
        private readonly Transform _transform;
        private Rigidbody2D _rigidbody2D;

        public PlayerController(Player player, Rigidbody2D rigidbody2D)
        {
            _transform = player._transformPlayer;
            _rigidbody2D = rigidbody2D;
            Speed = player._speed;
        }
        public float Speed { get; }
        public void Move(float horizontal, float vertical, float deltaTime)
        {
           var speed = deltaTime * Speed;
           Vector2 move = new Vector2(horizontal,vertical);
           move = Vector3.ClampMagnitude(move, speed);
           move.y = _rigidbody2D.velocity.y;
           _rigidbody2D.velocity = move;
        }
    }
