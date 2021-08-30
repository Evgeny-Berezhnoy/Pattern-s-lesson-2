using  UnityEngine;
    
public class BulletData
    {
        private Transform _barrel;
        private float _force;
        private Rigidbody2D _rigidbody2D;

        public float Force { get => _force; internal set => _force = value; }
        public Transform Barrel { get => _barrel; internal set => _barrel = value; }
        public Rigidbody2D Rigit { get => _rigidbody2D; internal set => _rigidbody2D = value; }
        public BulletData(Transform transform, float force, Rigidbody2D rigidbody2D)
        {
            Barrel = transform;
            Force = force;
            Rigit = rigidbody2D;
        }
    }
