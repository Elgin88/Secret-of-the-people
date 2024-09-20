using System;
using System.Runtime.CompilerServices;
using Infrastructure.Services.Factory;
using UnityEngine;

namespace Enemy.AI.Agents.Checkers
{
    public class CheckerAgro : MonoBehaviour
    {
        private Transform _playerTransform;
        public bool IsAgro { get; private set; }

        public void Construct(IGameFactory gameFactory)
        {
            _playerTransform = gameFactory.Player.transform;
        }

        private void FixedUpdate()
        {
            
        }
    }
}