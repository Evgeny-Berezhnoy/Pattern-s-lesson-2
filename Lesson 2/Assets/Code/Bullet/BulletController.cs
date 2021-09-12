using UnityEngine;

public class BulletController
{
    private BulletData bulletData;
    
    public BulletController(float damage, Collider2D collider2D)
    {
        bulletData = new BulletData(damage, collider2D);
    }
}
