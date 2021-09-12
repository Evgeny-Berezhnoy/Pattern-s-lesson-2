 using UnityEngine;

public class BulletData
{
    public float damage;
    public Collider2D bullet;
    public BulletData(float bulletDamage, Collider2D collider2D)
    {
        damage = bulletDamage;
        bullet = collider2D;
    }
}
