using UnityEngine;
public class BulletView : MonoBehaviour
    {
        [SerializeField] private float _damageBulletl;
        [SerializeField]private Transform _barrel;
        [SerializeField]private float _force;
        [SerializeField]private Rigidbody2D _rigidbody2D;
        private BulletController _bulletController;
        
        private void Start()
        {
            _bulletController = new BulletController(new BulletData(_barrel,_force,_rigidbody2D));
        }
        private void Update()
        {
            if (Input.GetButtonDown(NAME_MANAGER.LeftButtonMouse))
            {
               //_bulletController.CreateBullet(_rigidbody2D, _barrel.transform, _force);
            }
        }
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.GetComponent<Enemy>())
            {
                if(other.gameObject.GetComponent<Enemy>().Health.Current<=0) Destroy(other.gameObject);
                else
                { 
                    Damage(other.gameObject.GetComponent<Enemy>(), _damageBulletl);
                    Debug.Log($"{other.gameObject.GetComponent<Enemy>().Health.Current}");
                }
            }
        }
        
        private void Damage(Enemy hp,float damageBulls)
        {
            hp.Health.Current -= damageBulls;
        }
    }
