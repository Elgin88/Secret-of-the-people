using Infrastructure.Services.Factory;
using StaticData;
using UnityEngine;

namespace Enemy.AI.Agents.Checkers
{
    public class CheckerAgro : MonoBehaviour
    {
        [SerializeField] private MonsterStaticData _staticData;

        private IGameFactory _gameFactory;
        private Vector3 _playerPosition => _gameFactory.Player.transform.position;
        private Vector3 _position => transform.position;
        private float _agroRange => _staticData.AgroRange;

        public bool IsAgred { get; private set; }

        public void Construct(IGameFactory gameFactory) => _gameFactory = gameFactory;

        private void FixedUpdate()
        {
            IsAgred = TargetInAgroRange();
        }

        private bool TargetInAgroRange() => Vector3.Distance(_position, _playerPosition) < _agroRange;
    }
}