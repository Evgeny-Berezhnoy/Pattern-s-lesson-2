using UnityEngine;

namespace Code.Bullet
{
    public class Off:MonoBehaviour
    {
        private void OnCollisionEnter(Collision other)
        {
            if(other.collider.CompareTag("Enemy"))
                gameObject.SetActive(false);
        }
    }
}