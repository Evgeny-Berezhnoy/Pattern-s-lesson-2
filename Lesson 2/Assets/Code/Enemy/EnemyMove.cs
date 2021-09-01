using System;
using UnityEngine;
public class EnemyMove : Enemy
{
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private Rigidbody2D _rigidbody2DAsteroid;
    [SerializeField] private float _speed;

        public void EnemyAttack(Enemy transform, Transform player, Rigidbody2D rigidbody2D, float speed)
        {
           // rigidbody2D.velocity = (player.position - Enemy.).normalized * speed;
        }


        private void Update()
        {
           // EnemyAttack(_asteroidTransform, _playerTransform, _rigidbody2DAsteroid, _speed);
        }
    }
