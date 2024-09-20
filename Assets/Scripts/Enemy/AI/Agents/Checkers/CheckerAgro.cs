using Agava.YandexGames;
using Infrastructure.Services.Factory;
using StaticData;
using UnityEngine;

namespace Enemy.AI.Agents.Checkers
{
    public class CheckerAgro : MonoBehaviour
    {
        [SerializeField] private  MonsterStaticData _staticData;
        
        private Transform _player => _gameFactory.Player.transform;
        private IGameFactory _gameFactory;
        private float _delta = 1;

        public bool IsAgro { get; private set; }

        public void Construct(IGameFactory gameFactory)
        {
            _gameFactory = gameFactory;
        }

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
            
            Debug.Log(IsAgro);
        }

        private bool IsNotInAgroRange() => Vector3.Distance(transform.position, _player.position) > _staticData.AgroRange + _delta;

        private bool IsInAgroRange() => Vector3.Distance(transform.position, _player.position) < _staticData.AgroRange;
    }
}