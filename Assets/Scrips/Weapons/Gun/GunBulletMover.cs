using UnityEngine;

namespace Scripts.Weapons
{
    public class GunBulletMover : MonoBehaviour
    {
        [SerializeField] private GunBullet _bullet;

        private void Start()
        {
            Disable();
        }

        private void Update()
        {
            Move();
        }

        private void Move() => Vector3.MoveTowards(transform.position, transform.position + Vector3.forward, _bullet.Speed * Time.deltaTime);

        private void Disable() => enabled = false;
    }
}