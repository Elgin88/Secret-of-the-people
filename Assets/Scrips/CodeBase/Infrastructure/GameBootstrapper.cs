using Scripts.CodeBase.Infractructure.State;
using Scripts.Logic;
using UnityEngine;

namespace Scripts.CodeBase.Infractructure
{
    public class GameBootstrapper : MonoBehaviour, ICoroutineRunner
    {
        private Game _game;

        public Game Game => _game;

        public LoaderCurtain LoaderCurtain;

        private void Awake()
        {
            _game = new Game(this, LoaderCurtain);
            _game.StateMachine.Enter<BootstrapState>();

            DontDestroyOnLoad(this);
        }
    }
}