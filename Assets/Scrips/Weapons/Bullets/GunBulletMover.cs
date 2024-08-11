using UnityEngine;

namespace Scripts.Weapons
{
    public class GunBulletMover : MonoBehaviour
    {
        [SerializeField] private GunBullet _gunBullet;

        private void Awake()
        {
            Disable();
        }

        private void Update()
        {
            Move();
        }

        public void Enable() => enabled = true;

        public void Disable() => enabled = false;

        private void Move() => Vector3.MoveTowards(transform.position, transform.position + Vector3.forward, _gunBullet.Speed * Time.deltaTime);
    }
}