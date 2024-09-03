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
        private Vector3 _playerPosition => _gameFactory.Player.transform.position;
        private Vector3 _position => transform.position;
        private float _agroRange => _staticData.AgroRange;

        public Action Agred;

        public Action NotAgred;

        public void Construct(IGameFactory gameFactory) => _gameFactory = gameFactory;

        private void FixedUpdate()
        {
            if (IsAgroRange())
            {
                Agred?.Invoke();
            }
            else
            {
                NotAgred?.Invoke();
            }
        }

        public void Enabled()
        {
            SetEnabled(true);
        }

        public void Disable()
        {
            SetEnabled(false);
        }

        private void SetEnabled(bool status) => enabled = status;
        private bool IsAgroRange() => Vector3.Distance(_position, _playerPosition) < _agroRange;
    }
}