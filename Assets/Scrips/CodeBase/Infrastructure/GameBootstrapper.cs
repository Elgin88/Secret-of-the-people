using Scripts.CodeBase.Infractructure.State;
using Scripts.Logic;
using UnityEngine;

namespace Scripts.CodeBase.Infractructure
{
    public class GameBootstrapper : MonoBehaviour, ICoroutineRunner
    {
        private Game _game;

        private CurtainShower _curtainShower;

        private void Awake()
        {
            _game = new Game(this, _curtainShower);
            _game.StateMachine.Enter<BootstrapState>();

            DontDestroyOnLoad(this);
        }
    }
}