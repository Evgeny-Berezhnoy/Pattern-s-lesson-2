﻿using System;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

namespace Code.Bullet
{
    public class BulletPool : MonoBehaviour
    {
        [Serializable]
       public class Pool
        {
            public int size;
            public GameObject prefab;
            public Transform Transform;
        }
        public List<Pool> Pools;
        public Queue<GameObject> _Queue;

        private void Start()
        {
            _Queue = new Queue<GameObject>();
            foreach (var pool in Pools)
            {
                for (int i = 0; i < pool.size; i++)
                {
                    var obj = Instantiate(pool.prefab);
                    obj.SetActive(false);
                    _Queue.Enqueue(obj);
                }
            }
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                SpawnBullets();
                Debug.Log("xxx");
            }
        }

        public GameObject SpawnBullets()
        {
            var obj = _Queue.Dequeue();
            obj.SetActive(true);
            obj.GetComponent<Rigidbody2D>().velocity = transform.up*5f;
            obj.transform.localPosition = transform.position;
            obj.transform.localRotation = transform.rotation;
            return obj;
        }
        
    }
}