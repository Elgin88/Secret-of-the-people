using Scripts.CodeBase.Infractructure.Services;
using Scripts.CodeBase.Infractructure.State;
using Scripts.CodeBase.Services.Input;
using Scripts.Logic;

namespace Scripts.CodeBase.Infractructure
{
    public class Game 
    {
        public static IInputService InputService;

        public GameStateMashine StateMachine;

        public Game(ICoroutineRunner coroutineRunner, CurtainShower curtainShower)
        {
            StateMachine = new GameStateMashine(new SceneLoader(coroutineRunner), curtainShower, AllServices.Container);
        }
    }
}
