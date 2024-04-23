using Scripts.CodeBase.Infractructure.State;
using Scripts.Infractructure.Services;
using Scripts.Logic;
using Scripts.Services.Input;

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
