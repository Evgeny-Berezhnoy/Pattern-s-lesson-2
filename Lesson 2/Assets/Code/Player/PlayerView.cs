using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
    public class PlayerView : MonoBehaviour
    {
        
        [SerializeField] private float _speed;
        [SerializeField] private float _acceleration;
        [SerializeField] internal float Hp;
        [SerializeField] private Rigidbody2D _playerRigitBody;
        
        private Camera _camera;
        private IRotation _rotation;
        private IMove _moveTransform;
        private Ship _ship;
        private PlayerController _playerController;
        private Asteroid _asteroid;
        internal BigAsteroid _bigaster;
        private void Start()
        {
            _camera = Camera.main;
            _playerController = new PlayerController(new Player(transform, _speed, Hp), _playerRigitBody);
            var moveTransform = new AccelerationMove(transform, _speed, Hp,_acceleration);
            var rotation = new RotationShip(transform);
            _ship = new Ship(moveTransform, rotation);
            _asteroid = Enemy.CreateEnemyAsteroid(new Health(100, 50));
            _bigaster = Enemy.CreateBigAsteroid(new Health(150, 79));
            
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
            _playerController.Move(Input.GetAxis(NAME_MANAGER.HORIZONT), 
                Input.GetAxis(NAME_MANAGER.VERTICAL), Time.deltaTime);
        }
      
    }
