namespace Scripts.CodeBase.Infractructure
{
    public class Game
    {
        private GameStateMachine _gameStateMachine;

        public Game(GameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;

            _gameStateMachine.Enter<BootStraptState>();
        }
    }
}