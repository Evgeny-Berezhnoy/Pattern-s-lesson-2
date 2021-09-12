using UnityEngine;

public class Asteroid : Enemy
{
    private Health _asteroidsHealth;

    public Health AsteroidsHealth
    {
        get => _asteroidsHealth;
        set => _asteroidsHealth = value;
    }

    public static Asteroid CreateEnemyAsteroid(Health hp)
    {
        var asteroid = Instantiate(Resources.Load<Asteroid>("Asteroid"));
        asteroid.transform.position = new Vector2(Random.Range(-7f, 7f), Random.Range(-7f, 7f));
        asteroid.AsteroidsHealth = hp;
        return asteroid;
    }
}