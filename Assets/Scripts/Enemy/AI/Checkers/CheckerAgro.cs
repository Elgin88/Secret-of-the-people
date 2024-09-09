using System;
using Enemy.AI.Checkers.Starters;
using Enemy.AI.Checkers.Stoppers;
using Infrastructure.Services.Factory;
using StaticData;
using UnityEngine;

namespace Enemy.AI.Checkers
{
    [RequireComponent(typeof(StarterCheckerAgro))]
    [RequireComponent(typeof(StopperCheckerAgro))]
    
    public class CheckerAgro : MonoBehaviour
    {
        [SerializeField] private MonsterStaticData _staticData;

        private IGameFactory _gameFactory;
        private Vector3 _playerPosition => _gameFactory.Player.transform.position;
        private Vector3 _position => transform.position;
        private float _agroRange => _staticData.AgroRange;

        public Action OnAgred;

        public Action OnNotAgred;

        public void Construct(IGameFactory gameFactory) => _gameFactory = gameFactory;

        private void FixedUpdate()
        {
            if (IsAgroRange())
            {
                OnAgred?.Invoke();
            }
            else
            {
                OnNotAgred?.Invoke();
            }
        }

        public void On()
        {
            if (!enabled)
            {
                SetEnabled(true);
            }
        }

        public void Off()
        {
            if (enabled)
            {
                SetEnabled(false);
            }
        }

        private bool IsAgroRange() => Vector3.Distance(_position, _playerPosition) < _agroRange;
        private void SetEnabled(bool status) => enabled = status;
    }
}