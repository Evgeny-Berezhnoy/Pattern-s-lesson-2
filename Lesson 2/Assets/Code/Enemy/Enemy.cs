using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
        [SerializeField] private float _damageEnemy;
        private Transform _rootPool;
        private Health _health;
        public Health Health
        {
            get
            {
                if (Health.Current <= 0.0f)
                {
                    ReturnToPool();
                }
                return _health;
            }
        }
        public Transform RotPool
        {
            get
            {
                if (_rootPool == null)
                {
                    var Find = GameObject.Find(NAME_MANAGER.POOL_AMMUNITION);
                    _rootPool = Find == null ? null : Find.transform;
                }
                return _rootPool;
            }
        }
        public void ActiveEnemy(Vector3 pos, Quaternion rot)
        {
            transform.localPosition = pos;
            transform.localRotation = rot;
            gameObject.SetActive(true);
            transform.SetParent(null);
        }

        public void ReturnToPool()
        {
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            gameObject.SetActive(false);
            transform.SetParent(_rootPool);
            if(!_rootPool)
            {
                Destroy(gameObject);
            }
        }
        public static Asteroid CreateEnemyAsteroid(Health hp)
        {
            var enemy = Instantiate(Resources.Load<Asteroid>("Asteroid"));
            enemy.transform.position = new Vector2(Random.Range(-7f,7f),Random.Range(-7f,7f));
            enemy._health = hp;
            return enemy;
        }
        public static BigAsteroid CreateBigAsteroid(Health hp)
        {
            var bigAsteroid = Instantiate(Resources.Load<BigAsteroid>("Big"));
            bigAsteroid.transform.position = new Vector2(Random.Range(-7f, 7f), Random.Range(3f, -3f));
            bigAsteroid._health = hp;
            return bigAsteroid;
        }
        public void DamagePlayer(PlayerView hp, float damage)
        {
            hp.Hp -= damage;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.GetComponent<PlayerView>())
            {
                if (other.gameObject.GetComponent<PlayerView>().Hp <= 0) Destroy(other.gameObject);
                else
                {
                    DamagePlayer(other.gameObject.GetComponent<PlayerView>(), _damageEnemy);
                    Debug.Log($" Player hp : {other.gameObject.GetComponent<PlayerView>().Hp}");
                }
            }
        }
}
