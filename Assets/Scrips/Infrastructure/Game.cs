namespace Scripts.CodeBase.Infractructure
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

        public static void SetIsReadyTrue()
        {
            _isReadyGame = true;
        }
    }
}