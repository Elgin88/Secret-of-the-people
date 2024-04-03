using UnityEngine;

namespace CodeBase.Infractructure
{
    internal class GameBootstrapper : MonoBehaviour
    {
        private Game _game;

        internal Game Game => _game;

        private void Awake()
        {
            DontDestroyOnLoad(this);
        }

        internal void InitGame()
        {
            _game = new Game();
        }
    }
}