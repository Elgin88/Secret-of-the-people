using Scripts.CodeBase.Logic;
using Scripts.StaticData;
using System;
using UnityEngine;

namespace Scripts.Weapons
{
    public class GunBullet : MonoBehaviour, IBullet
    {
        [SerializeField] private BulletStaticData _staticData;

        private IGameFactory _iGameFactory;

        private float _startSpeed;

        public float Speed => _startSpeed;

        public void Construct(IGameFactory gameFactory)
        {
            SetIGameFactory(gameFactory);
            SetStartSpeed();
        }

        private void SetIGameFactory(IGameFactory gameFactory) => _iGameFactory = gameFactory;

        private void SetStartSpeed() => _startSpeed = _staticData.Speed;
    }
}