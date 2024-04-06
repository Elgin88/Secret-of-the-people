using Scripts.CodeBase.Services.Input;
using UnityEngine;

namespace Scripts.CodeBase.Infractructure
{
    internal class Game
    {
        public static IInputService InputService;

        public Game()
        {
            SelectInputService();
        }

        private static void SelectInputService()
        {
            if (Application.isEditor)
            {
                InputService = new StandaloneInputService();
            }
            else
            {
                InputService = new MobileInputService();
            }
        }
    }
}