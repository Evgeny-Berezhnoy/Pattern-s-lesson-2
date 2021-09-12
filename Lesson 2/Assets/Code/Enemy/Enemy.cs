using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _damageEnemy;
    private Transform _rootPool;
    private Health _bigAsteroid;


    public Health BigAsteroid
    {
        get => _bigAsteroid;
        set => _bigAsteroid = value;
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
