using UnityEngine;

public class BulletController
{
    private Transform _barrel;
    private float _force;
    private Rigidbody2D _rigidbody2D;
    public BulletController(BulletData bulletData)
    {
        _barrel = bulletData._barrel;
        _force = bulletData._force;
        _rigidbody2D = bulletData._rigidbody2D;
    }
        public void CreateBullet(Rigidbody2D rigidbody2D, Transform transform, float force)
        {
            var bul = Object.Instantiate(rigidbody2D, transform.position, transform.rotation);
            bul.AddForce(transform.up * force,ForceMode2D.Impulse);
        }
    }
