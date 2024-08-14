using UnityEngine;

namespace Scripts.WeaponsComponents
{
    public class GunBulletMover : MonoBehaviour
    {
        [SerializeField] private GunBullet _bullet;

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

        private void Move() => Vector3.MoveTowards(transform.position, transform.position + Vector3.forward, _bullet.StartSpeed * Time.deltaTime);
    }
}