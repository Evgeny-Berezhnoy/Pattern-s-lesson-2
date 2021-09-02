using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
    {
        public Health Health { get; private set; }
        public static Asteroid CreateEnemyAsteroid(Health hp)
        {
            var enemy = Instantiate(Resources.Load<Asteroid>("Asteroid"));
            enemy.transform.position = new Vector2(Random.Range(-7f,7f),Random.Range(-7f,7f));
            enemy.Health = hp;
            return enemy;
        }
        public static BigAsteroid CreateBigAsteroid(Health hp)
        {
            var bigAsteroid = Instantiate(Resources.Load<BigAsteroid>("Big"));
            bigAsteroid.transform.position = new Vector2(Random.Range(-7f, 7f), Random.Range(3f, -3f));
            bigAsteroid.Health = hp;
            return bigAsteroid;
        }
    }
