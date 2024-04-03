using CodeBase.Services.Input;
using UnityEngine;

namespace CodeBase.Infractructure
{
    internal class Game
    {
        public static IInputService InputService;

        public Game()
        {
            SelectionInputService();
        }

        private static void SelectionInputService()
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