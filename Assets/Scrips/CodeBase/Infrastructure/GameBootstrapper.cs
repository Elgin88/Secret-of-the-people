using UnityEngine;

namespace Scripts.CodeBase.Infractructure
{
    internal class GameBootstrapper : MonoBehaviour
    {
        private Game _game;

        internal Game Game => _game;

        private void Awake()
        {
            if (_game == null)
            {
                _game = new Game();
            }

            DontDestroyOnLoad(this);
        }

        internal void InitGame()
        {
            _game = new Game();
        }
    }
}