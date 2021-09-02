using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
        [SerializeField] private float _damageEnemy;
        public Health Health { get;  set; }
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
        public void DamagePlayer(PlayerView hp, float damage)
        {
            hp._hp -= damage;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.GetComponent<PlayerView>())
            {
                if (other.gameObject.GetComponent<PlayerView>()._hp <= 0) Destroy(other.gameObject);
                else
                {
                    DamagePlayer(other.gameObject.GetComponent<PlayerView>(), _damageEnemy);
                    Debug.Log($" Player hp : {other.gameObject.GetComponent<PlayerView>()._hp}");
                }
            }

        }
}
