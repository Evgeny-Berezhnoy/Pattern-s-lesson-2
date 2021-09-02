using UnityEngine;
using  System.Collections;

public class EnemyMove : Enemy

{
   [SerializeField] private float _speed;
   [SerializeField] private GameObject obj;
   private PlayerView _playerView;

   private void Start()
   {
      _playerView = FindObjectOfType<PlayerView>();
   }
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
