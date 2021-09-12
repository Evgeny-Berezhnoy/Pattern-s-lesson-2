using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Code.Bullet
{
    public class BulletPool : MonoBehaviour
    {
        public float size;
        public GameObject prefab;
        public Transform AIM;
        private List<GameObject> _objectsPool;

        private void Start()
        {
            _objectsPool = new List<GameObject>();
            Init();
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                CreateBullet();
            }
        }

        public void Init()
        {
            for (int i = 0; i < size; i++)
            {
                var obj = Instantiate(prefab);
                obj.SetActive(false);
                obj.transform.SetParent(transform);
                _objectsPool.Add(obj);
            }
        }

        public void CreateBullet()
        {
            foreach (var bullet in _objectsPool)
            {
                if (!bullet.activeSelf)
                {
                    bullet.transform.position = AIM.transform.position;
                    bullet.transform.rotation = AIM.transform.rotation;
                    bullet.SetActive(true);
                    bullet.GetComponent<Rigidbody2D>().velocity = AIM.up * 10f;
                    StartCoroutine(Return(2, bullet));
                    return;
                }
            }
        }

        private IEnumerator Return(float time, GameObject gO)
        {
            yield return new WaitForSeconds(time);
            gO.SetActive(false);
        }
    }
}