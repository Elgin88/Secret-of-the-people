﻿using Infrastructure.Services.Factory;
using StaticData;
using UnityEngine;

namespace Enemy.AI.Agents.Checkers
{
    public class CheckerAgro : MonoBehaviour
    {
        [SerializeField] private  MonsterStaticData _staticData;
        
        private IGameFactory _gameFactory;
        private Transform _playerTransform => _gameFactory.Player.transform;
        private float _delta = 0.2f;

        public bool IsAgro { get; private set; }

        public void Construct(IGameFactory gameFactory) => _gameFactory = gameFactory;

        private void FixedUpdate()
        {
            if (IsNotInAgroRange())
            {
                IsAgro = false;
            }
            else if (IsInAgroRange())
            {
                IsAgro = true;
            }
        }

        private bool IsNotInAgroRange() => Vector3.Distance(transform.position, _playerTransform.position) > _staticData.AgroRange + _delta;
        private bool IsInAgroRange() => Vector3.Distance(transform.position, _playerTransform.position) < _staticData.AgroRange;
    }
}