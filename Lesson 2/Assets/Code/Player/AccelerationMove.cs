using UnityEngine;

internal sealed class AccelerationMove : Player, IMove
    {
        private readonly float _acceleration;
        public AccelerationMove(Transform transformPlayer, float speed, float hp, float acceleration) : base(transformPlayer, speed, hp)
        {
            _acceleration = acceleration;
        }

        public void AddAcceleration()
        { 
            Speed += _acceleration;
        }

        public void RemoveAcceleration()
        {
            Speed -= _acceleration;
        }

        public void Move(float horizontal, float vertical, float deltaTime)
        {
            
        }
    }
