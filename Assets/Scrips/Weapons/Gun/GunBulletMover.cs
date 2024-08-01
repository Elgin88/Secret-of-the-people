using Scripts.StaticData;
using UnityEngine;

namespace Scripts.Weapons
{
    public class GunBulletMover : Bullet
    {
        [SerializeField] private BulletStaticData _staticData;

        private float _startSpeed;

        public override float StartSpeed => _startSpeed;

        private void Awake()
        {
            SetStartSpeed();
        }

        private void SetStartSpeed() => _startSpeed = _staticData.Speed;
    }
}