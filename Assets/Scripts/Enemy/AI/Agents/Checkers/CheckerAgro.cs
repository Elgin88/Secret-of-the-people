using Infrastructure.Services.Factory;
using UnityEngine;

namespace Enemy.AI.Agents.Checkers
{
    public class CheckerAgro : MonoBehaviour
    {
        private IGameFactory _gameFactory;
        public bool IsAgro { get; private set; }

        public void Construct(IGameFactory gameFactory)
        {
            _gameFactory = gameFactory;
        }

        private void FixedUpdate()
        {
            
        }
    }
}