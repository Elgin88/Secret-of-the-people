using System;
using System.Collections.Generic;
using Unity.VisualScripting;

namespace Scripts.CodeBase.Infractructure
{
    public class GameStateMashine
    {
        private Dictionary<Type, IState> _states;
        private IState _currentState;

        public GameStateMashine(SceneLoader sceneLoader)
        {
            _states = new Dictionary<Type, IState>
            {
                [typeof(BootstrapState)] = new BootstrapState(this, sceneLoader),
                [typeof(LoadLevelState)] = new LoadLevelState(this, sceneLoader),
            };
        }

        public void Enter<TState>() where TState : IState
        {
            _currentState?.Exit();
            IState state = _states[typeof(TState)];
            _currentState = state;
            state.Enter();
        }
    }
}