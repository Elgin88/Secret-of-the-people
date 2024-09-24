using Infrastructure.Services.Factory;
using StaticData;
using UnityEngine;

namespace Enemy.AI.Agents.Checkers
{
    public class CheckerAttackRange : MonoBehaviour
    {
        [SerializeField] private MonsterStaticData _staticData;

        private IGameFactory _gameFactory;
        private const float _delta = 0.1f;

        public bool IsRange { get; private set; }

        public void Construct(IGameFactory gameFactory) => _gameFactory = gameFactory;

        private void FixedUpdate()
        {
            if (GetIsAttackRange())
            {
                IsRange = true;
            }
            else if (GetIsNotAttackRange())
            {
                IsRange = false;
            }
        }

        private bool GetIsAttackRange() =>
            Vector3.Distance(transform.position, _gameFactory.Player.transform.position) <
            _staticData.AttackRange;

        private bool GetIsNotAttackRange() =>
            Vector3.Distance(transform.position, _gameFactory.Player.transform.position) >
            _staticData.AttackRange + _delta;
    }
}