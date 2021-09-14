 using UnityEngine;

public class BulletData
{
    private float damage;
    private Collider2D bullet;

    public BulletData(float bulletDamage, Collider2D collider2D)
    {
        damage = bulletDamage;
        bullet = collider2D;
    }
}
