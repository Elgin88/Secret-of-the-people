using UnityEngine;

namespace Secret.Weapons.GunBullet
{
    public class GunBullet : MonoBehaviour
    {
        private void Awake()
        {
            gameObject.SetActive(false);
        }

        public void SetPosition(Vector3 position)
        {
            transform.position = position;
        }

        public void SetRotation(Quaternion rotation)
        {
            transform.rotation = rotation;
        }
    }
}