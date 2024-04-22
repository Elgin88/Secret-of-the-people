using Scripts.CodeBase.Infractructure.State;
using Scripts.Logic;
using UnityEngine;

namespace Scripts.CodeBase.Infractructure
{
    public class GameBootstrapper : MonoBehaviour, ICoroutineRunner
    {
        private Game _game;

        public CurtainShower CurtainShower;

        private void Awake()
        {
            _game = new Game(this, CurtainShower);
            _game.StateMachine.Enter<BootstrapState>();

            DontDestroyOnLoad(this);
        }
    }
}