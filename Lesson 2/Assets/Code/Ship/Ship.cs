using UnityEngine;
using UnityEngine.Rendering;

internal sealed class Ship : IMove,IRotation
    {
        private readonly IMove _moveImplementation;
        private readonly IRotation _rotationImplemention;

        public float Speed => _moveImplementation.Speed;
       
        public Ship(IMove moveImplementation, IRotation rotationImplemention)
        {
            _moveImplementation = moveImplementation;
            _rotationImplemention = rotationImplemention;
        }

        public void Rotation(Vector3 direction)
        {
            _rotationImplemention.Rotation(direction);
        }
        public void Move(float horizontal, float vertical, float deltaTime)
        {
            /// загллшка
        }
        public void AddAAcceleration()
        {
            if (_moveImplementation is AccelerationMove accelerationMove)
            {
                accelerationMove.AddAcceleration();
            }
        }
        public void RemoveAcceleration()
        {
            if (_moveImplementation is AccelerationMove accelerationMove)
            {
                accelerationMove.RemoveAcceleration();
            }
        }

    }
