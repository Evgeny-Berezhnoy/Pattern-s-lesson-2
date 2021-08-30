using UnityEngine;

public class BulletController
{
    private Transform _barrel;
    private float _force;
    private Rigidbody2D _rigidbody2D;
    public BulletController(BulletData bulletData)
    {
        _rigidbody2D = bulletData.Rigit;
        _barrel = bulletData.Barrel;
        _force = bulletData.Force;
        
    }
        public void CreateBullet(Rigidbody2D rigidbody2D, Transform transform, float force)
        {
            var bul = Object.Instantiate(rigidbody2D, transform.position, transform.rotation);
            bul.AddForce(Vector2.up * force);
        }
    }
