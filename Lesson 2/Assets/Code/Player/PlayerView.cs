using System;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
[Serializable]
public class PlayerView : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _acceleration;
    [SerializeField] private Rigidbody2D _playerRigitBody;
    private Health HealthPlayer;
    public Health PlayerHP
    {
        get => HealthPlayer;
        set => HealthPlayer = value;
    }
    private Camera _camera;
    private IRotation _rotation;
    private IMove _moveTransform;
    private Ship _ship;
    private PlayerController _playerController;
    private Enemy _asteriod;
    
    private Enemy _bigAsteriod;
    private Enemy _bigAsteriod1;


    private BulletView _bulletView;

    private void Start()
    {
        _camera = Camera.main;
        HealthPlayer = new Health(150, 150);
        _playerController = new PlayerController(new Player(transform, _speed, HealthPlayer), _playerRigitBody);
        var moveTransform = new AccelerationMove(transform, _speed, HealthPlayer, _acceleration);
        var rotation = new RotationShip(transform);
        _ship = new Ship(moveTransform, rotation);
        _bigAsteriod = BigAsteroid.CreateBigAsteroid(new Health(100, 77));
      //  _bigAsteriod1 = BigAsteroid.CreateBigAsteroid(new Health(100, 77)).CopyObj();
        _asteriod = Asteroid.CreateEnemyAsteroid(new Health(111, 88));
        Debug.Log($"{_bigAsteriod}");
        Debug.Log($"{_asteriod}");
        Debug.Log($"{HealthPlayer.Current}");
    }

    private void Update()
    {
        var direction = Input.mousePosition - _camera.WorldToScreenPoint(transform.position);
        _ship.Rotation(direction);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            _ship.AddAAcceleration();
        }

        if (Input.GetKey(KeyCode.LeftShift))
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