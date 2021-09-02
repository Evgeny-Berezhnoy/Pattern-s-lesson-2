
using System;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class BulletView : MonoBehaviour
    {
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
            if (Input.GetButtonDown("Fire1"))
            {
                _bulletController.CreateBullet(_rigidbody2D, _barrel.transform, _force);
            }
        }
    }
