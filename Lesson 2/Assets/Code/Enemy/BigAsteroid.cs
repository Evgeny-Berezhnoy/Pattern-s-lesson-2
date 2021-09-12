using UnityEngine;

public class BigAsteroid : Enemy
{
    public static BigAsteroid CreateBigAsteroid(Health hp)
    {
        var bigAsteroid = Instantiate(Resources.Load<BigAsteroid>("Big"));
        bigAsteroid.transform.position = new Vector2(Random.Range(-7f, 7f), Random.Range(3f, -3f));
        bigAsteroid.BigAsteroid = hp;
        return bigAsteroid;
    }
}
