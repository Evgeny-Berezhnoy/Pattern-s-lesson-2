using System;
using UnityEngine;
using Random = UnityEngine.Random;

[Serializable]
public class BigAsteroid : Enemy
{
    private Health _bigAsteroids;

    public Health BigAsteroids
    {
        get => _bigAsteroids;
        set => _bigAsteroids = value;
    }

    public static BigAsteroid CreateBigAsteroid(Health hp)
    {
        var bigAsteroid = Instantiate(Resources.Load<BigAsteroid>("Big"));
        bigAsteroid.transform.position = new Vector2(Random.Range(-7f, 7f), Random.Range(3f, -3f));
        bigAsteroid.BigAsteroids = hp;
        return bigAsteroid;
    }
}
