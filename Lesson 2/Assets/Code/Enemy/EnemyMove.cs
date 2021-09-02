using UnityEngine;
public class EnemyMove : Enemy
{
   [SerializeField] private float _speed;
    
   private Rigidbody2D _rigidbody2DAsteroid;
    private Vector3 EnemyFindTransform;
    private Vector3 PlayerFindTransform;

    private void Start()
    { 
       EnemyFindTransform = FindObjectOfType<BigAsteroid>().transform.position;
       PlayerFindTransform = FindObjectOfType<PlayerView>().transform.position;
       _rigidbody2DAsteroid = FindObjectOfType<Rigidbody2D>();
    }

    public void EnemyAttack(Vector2 player, Vector2 enemy, Rigidbody2D rigidbody2D,float speed)
        { 
           var vector = enemy - player;
          rigidbody2D.AddForce(vector*speed);
        }


        private void FixedUpdate()
        {
           EnemyAttack(EnemyFindTransform, PlayerFindTransform, _rigidbody2DAsteroid, _speed);
        }
    }
