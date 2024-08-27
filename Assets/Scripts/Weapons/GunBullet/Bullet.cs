﻿using Infrastructure.Services.Factory;
using Player;
using StaticData;
using UnityEngine;
using Weapons.Interfaces;

namespace Weapons.GunBullet
{
    [RequireComponent(typeof(CollisionChecker))]
    [RequireComponent(typeof(Destroyer))]
    [RequireComponent(typeof(Mover))]

    public class Bullet : MonoBehaviour, IBullet
    {
        [SerializeField] private BulletStaticData _staticData;
        [SerializeField] private Mover _mover;

        private IGameFactory _gameFactory;

        private float _startSpeed;

        public float StartSpeed => _startSpeed;

        public void Construct(IGameFactory gameFactory)
        {
            SetIGameFactory(gameFactory);
            ConstructMover(gameFactory);
        }

        private void Awake()
        {
            SetStartSpeed();
            DisableGameObject();
        }

        public void Fly()
        {
            SetStartPosition();
            StartMove();
        }

        private void StartMove() => _mover.StartMove();

        private void DisableGameObject() => gameObject.SetActive(false);

        private void SetStartPosition() => transform.position = _gameFactory.Player.GetComponent<ShootPointSetter>().ShootPoint.transform.position;

        private void SetIGameFactory(IGameFactory gameFactory) => _gameFactory = gameFactory;

        private void SetStartSpeed() => _startSpeed = _staticData.Speed;

        private void ConstructMover(IGameFactory gameFactory) => _mover.Construct(gameFactory);
    }
}