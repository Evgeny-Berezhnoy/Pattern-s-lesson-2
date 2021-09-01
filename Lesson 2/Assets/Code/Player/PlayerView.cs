using System;
using Code;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
    public class PlayerView : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _acceleration;
        [SerializeField] private float _hp;
        [SerializeField] private Rigidbody2D _playerRigitBody;
        
        private Camera _camera;
        private IRotation _rotation;
        private IMove _moveTransform;
        private Ship _ship;
        private Vector2 _vector2;
        private PlayerController _playerController;
        private EnemyMove _enemyMove;
        
        internal void Awake()
        {
            _playerController = new PlayerController(new Player(transform, _speed, _hp), _playerRigitBody);
        }
        private void Start()
        {
            _camera = Camera.main;
            var moveTransform = new AccelerationMove(transform, _speed, _hp,_acceleration);
            var rotation = new RotationShip(transform);
            _ship = new Ship(moveTransform, rotation);
            Enemy.CreateEnemyAsteroid(new Health(100, 50));
            Enemy.CreateBigAsteroid(new Health(150, 79));
        }
        private void Update()
        {
            var direction = Input.mousePosition - _camera.WorldToScreenPoint(transform.position);
            _ship.Rotation(direction);
            
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                _ship.AddAAcceleration();
            }

            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                _ship.RemoveAcceleration();
            }
        }

        private void FixedUpdate()
        {
            _playerController.Move(Input.GetAxis(NAME_NUMBERS.HORIZONT), 
                Input.GetAxis(NAME_NUMBERS.VERTICAL), Time.deltaTime);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if(_hp<=0) Destroy(gameObject);
            else
            {
                _hp--;
            }
        }
    }
