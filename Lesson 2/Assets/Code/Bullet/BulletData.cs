using  UnityEngine;
    
public class BulletData
    {
        internal Transform _barrel;
        internal float _force;
        internal Rigidbody2D _rigidbody2D;
       
        public BulletData(Transform transform, float force, Rigidbody2D rigidbody2D)
        {
            _barrel = transform;
            _force = force;
            _rigidbody2D = rigidbody2D;
        }
    }
