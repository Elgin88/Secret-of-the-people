using System;
using Infrastructure.Services.Factory;
using StaticData;
using UnityEngine;

namespace Enemy.Agents.MoveToPlayer
{
    public class AgroSetter : MonoBehaviour
    {
        [SerializeField] private MonsterStaticData _staticData;

        private IGameFactory _gameFactory;
        private float _agroRange => _staticData.AgroRange;
        
        public bool IsAgro { get; private set; }
        
        public void Construct(IGameFactory gameFactory) => _gameFactory = gameFactory;

        private void FixedUpdate() => SetIsAgro(IsMinDistance());

        public void Enable() => enabled = true;

        public void Disable() => enabled = false;

        private void SetIsAgro(bool status) => IsAgro = status;

        private bool IsMinDistance() => Vector3.Distance(transform.position, _gameFactory.Player.transform.position) < _agroRange;
    }
}