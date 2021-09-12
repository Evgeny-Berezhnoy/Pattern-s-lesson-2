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
    private Enemy _asteriod;
    private Enemy _bigAsteriod;


    private BulletView _bulletView;

    private void Start()
    {
        _camera = Camera.main;
        _playerController = new PlayerController(new Player(transform, _speed, Hp), _playerRigitBody);
        var moveTransform = new AccelerationMove(transform, _speed, Hp, _acceleration);
        var rotation = new RotationShip(transform);
        _ship = new Ship(moveTransform, rotation);
        _bigAsteriod = BigAsteroid.CreateBigAsteroid(new Health(100, 77));
        _asteriod = Asteroid.CreateEnemyAsteroid(new Health(111, 88));
        Debug.Log($"{_bigAsteriod.BigAsteroid.Current}/{_bigAsteriod.BigAsteroid.Max}");
        Debug.Log($"{_asteriod}");
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