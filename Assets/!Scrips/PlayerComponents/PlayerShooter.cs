using Scripts.Bullets;
using Scripts.Static;
using Scripts.Weapons;
using UnityEngine;

namespace Scripts.PlayerComponents
{
    public class PlayerShooter : MonoBehaviour
    {
        private const int _radius = 3;
        private Bullet _bullet;
        private Collider[] _results = new Collider[10];
        private int _layerMask;

        private void Awake()
        {
            _layerMask = 1 << StaticLayersNames.Enemy;
        }

        public void Shoot(Weapon weapon)
        {
            weapon.Shoot(_bullet);
        }

        public void Update()
        {
            int countOfEnemy = Physics.OverlapSphereNonAlloc(transform.position, _radius, _results, _layerMask);

            Debug.Log(countOfEnemy);

            if (countOfEnemy == 0)
            {
                _results = new Collider[10];
            }
        }
    }
}