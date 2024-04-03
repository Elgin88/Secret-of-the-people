using UnityEngine;

namespace CodeBase.Infractructure
{
    internal class GameBootstrapper : MonoBehaviour
    {
        private Game _game;

        internal Game Game => _game;

        private void Awake()
        {
            _game = new Game();

            DontDestroyOnLoad(this);
        }
    }
}