using Scripts.CodeBase.Infractructure.State;
using Scripts.Logic;
using UnityEngine;

namespace Scripts.CodeBase.Infractructure
{
    public class GameBootstrapper : MonoBehaviour, ICoroutineRunner
    {
        private Game _game;

        public Game Game => _game;

        private void Awake()
        {
            _game = new Game(this);
            _game.StateMachine.Enter<BootstrapState>();

            DontDestroyOnLoad(this);
        }
    }
}