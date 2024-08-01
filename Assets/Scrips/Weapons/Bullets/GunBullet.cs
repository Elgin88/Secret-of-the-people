using System;
using Scripts.CodeBase.Logic;
using Scripts.StaticData;
using UnityEngine;

namespace Scripts.Weapons
{
    public class GunBullet : Bullet
    {
        [SerializeField] private BulletStaticData _staticData;

        private IGameFactory _iGameFactory;

        private float _startSpeed;

        public override float StartSpeed => _startSpeed;

        private void Awake() => SetStartSpeed();

        public void Construct(IGameFactory gameFactory)
        {
            _iGameFactory = gameFactory;
        }

        private void SetStartSpeed() => _startSpeed = _staticData.Speed;
    }
}