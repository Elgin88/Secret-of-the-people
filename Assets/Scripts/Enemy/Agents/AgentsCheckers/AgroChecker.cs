using System;
using Infrastructure.Services.Factory;
using StaticData;
using UnityEngine;

namespace Enemy.Agents.AgentsCheckers
{
    public class AgroChecker : MonoBehaviour
    {
        [SerializeField] private MonsterStaticData _staticData;

        private IGameFactory _gameFactory;
        private float _agroRange => _staticData.AgroRange;
        private Vector3 _position => transform.position;
        private Vector3 _playerPosition => _gameFactory.Player.transform.position;

        public Action Agred;

        public void Construct(IGameFactory gameFactory) => _gameFactory = gameFactory;

        private void FixedUpdate()
        {
            if (IsAgroRange())
            {
                Agred?.Invoke();
            }
        }

        public void On()
        {
            enabled = true;
        }

        public void Off()
        {
            enabled = false;
        }

        private bool IsAgroRange() => Vector3.Distance(_position, _playerPosition) < _agroRange;
    }
}