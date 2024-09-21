using Infrastructure.Services.Factory;
using StaticData;
using UnityEngine;

namespace Enemy.AI.Agents.Checkers
{
    public class CheckerIsInAttackRange : MonoBehaviour
    {
        [SerializeField] private MonsterStaticData _staticData;

        private IGameFactory _gameFactory;
        private float _delta = 0.1f;
        
        public bool IsAttackRange { get; private set; }

        public void Construct(IGameFactory gameFactory) => _gameFactory = gameFactory;

        private void FixedUpdate()
        {
            if (GetIsAttackRange())
            {
                IsAttackRange = true;
            }
            else if (GetIsNotAttackRange())
            {
                IsAttackRange = false;
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