using UnityEngine;

namespace Scripts.CodeBase.Infractructure
{
    public class GameBootstrapper : MonoBehaviour, ICoroutineRunner
    {
        private Game _game;

        public Game Game => _game;

        private void Awake()
        {
            _game = new Game(new GameStateMachine(new SceneLoader(this), AllServices.Container));

            DontDestroyOnLoad(this);
        }
    }
}