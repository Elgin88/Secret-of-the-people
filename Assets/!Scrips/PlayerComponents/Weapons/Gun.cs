using Scripts.CodeBase.Logic;
using Scripts.PlayerComponents;
using UnityEngine;

namespace Scripts.Weapons
{
    public class Gun : Weapon
    {
        [SerializeField] private float _intervalBetweenBullets;
        [SerializeField] private float _durationReload;
        [SerializeField] private int _numberBulletsInClip;
        [SerializeField] private GameObject _bullet;

        private Transform _shootPoint;
        private IGameFactory _iGameFactory;
        private PlayerShooter _playerShooter;

        public override float IntervelBetweenBullets => _intervalBetweenBullets;

        public override float DurationReload => _durationReload;

        public override int NumberBulletsInClip => _numberBulletsInClip;

        private void Awake()
        {
            _iGameFactory = AllServices.Container.Get<IGameFactory>();
            _playerShooter = _iGameFactory.Player.GetComponent<PlayerShooter>();

            Debug.Log(_playerShooter);
        }

        public override void Shoot()
        {
            Instantiate(_bullet, _shootPoint.position, Quaternion.identity);
        }

        public override void Reload()
        {
        }
    }
}