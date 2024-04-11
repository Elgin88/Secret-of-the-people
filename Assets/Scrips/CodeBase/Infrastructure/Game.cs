using Scripts.CodeBase.Services.Input;

namespace Scripts.CodeBase.Infractructure
{
    public class Game
    {
        public static IInputService InputService;

        public GameStateMashine StateMachine;

        public Game(ICoroutineRunner coroutineRunner)
        {
            StateMachine = new GameStateMashine(new SceneLoader(coroutineRunner));
        }
    }
}