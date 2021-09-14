using UnityEngine;

public class BulletView : MonoBehaviour
{
    public float damageBullet;
    public Collider2D bulletCollaider;
    private BulletData bulletData;
    private BulletController _bulletController;

    private void Start()
    {
        _bulletController = new BulletController(damageBullet, bulletCollaider);
    }

    private void DamageAsteroid(Asteroid hp, float damageBulls)
    {
        hp.AsteroidsHealth.Current -= damageBulls;
    }

    private void DamageBigAsteroid(BigAsteroid hp, float damageBulls)
    {
        hp.BigAsteroids.Current -= damageBulls;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent(out Asteroid enemy))
        {
            DamageAsteroid(enemy.GetComponent<Asteroid>(), damageBullet);
            if (enemy.AsteroidsHealth.Current <= 0)
            {
                enemy.gameObject.SetActive(false);
            }

            Debug.Log($"{enemy.AsteroidsHealth.Current}");
        }

        else if (other.gameObject.TryGetComponent(out BigAsteroid Big))
        {
            DamageBigAsteroid(Big.GetComponent<BigAsteroid>(), damageBullet);
            if (Big.BigAsteroids.Current <= 0)
            {
                Big.gameObject.SetActive(false);
            }

            Debug.Log($"{Big.BigAsteroids.Current}");
        }
    }
}
