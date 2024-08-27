using Infrastructure.Services.Input;
using Infrastructure.States;

namespace Infrastructure
{
    public class Game
    {
        private static bool _isReadyGame = false;

        public static bool IsReady => _isReadyGame;

        public static IInputService InputService { get; set; }

        public Game(GameStateMachine gameStateMachine)
        {
            gameStateMachine.Enter<StateBootStrapt>();
        }

        public static void SetIsReady() => _isReadyGame = true;
    }
}