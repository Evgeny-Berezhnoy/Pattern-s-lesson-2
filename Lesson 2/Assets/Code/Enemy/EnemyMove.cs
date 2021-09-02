using UnityEngine;
using  System.Collections;

public class EnemyMove : Enemy

{
   [SerializeField] private float _speed;
   [SerializeField] private GameObject obj;
   //private Asteroid _asteroid;
   private PlayerView _playerView;

   private void Start()
   {
      //_asteroid = FindObjectOfType<Asteroid>(); 
      _playerView = FindObjectOfType<PlayerView>();
   }

   /* public void EnemyAttack(Transform Asteroid,Transform BigAsteroid, Transform player, Rigidbody2D rigidbody2D,float speed)
        { 
           var vector = player.transform.position - Asteroid.transform.position ;
           var vector1 = player.transform.position - BigAsteroid.transform.position ;
           transform.Translate(vector * (speed* Time.deltaTime));
           //transform.Translate(vector1 * (speed* Time.deltaTime));
          //rigidbody2D.AddForce(a*speed);
          Debug.Log($"enemy : {Asteroid.transform.position}");
          Debug.Log($"player:{player.transform.position}");
          Debug.Log($"enemy - player:{Asteroid.transform.position - player.transform.position}");
        }*/

   public void EnemyAttack(Transform asteroid,Transform player, float speed)
   {
      var vector = player.transform.position - asteroid.transform.position;
      transform.Translate(vector * (speed * Time.deltaTime));
   }
   private void FixedUpdate()
   {
      EnemyAttack(obj.transform ,_playerView.transform, _speed);
   }
}
