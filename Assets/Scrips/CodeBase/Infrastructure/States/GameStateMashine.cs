using System;
using System.Collections.Generic;
using Scripts.CodeBase.Infractructure.Factory;
using Scripts.CodeBase.Infractructure.Services;
using Scripts.Logic;

namespace Scripts.CodeBase.Infractructure.State
{
    public class GameStateMashine
    {
        private Dictionary<Type, IExitableState> _states;
        private IExitableState _activeState;

        public GameStateMashine(SceneLoader sceneLoader, CurtainShower loaderCurtain, AllServices allServises)
        {
            _states = new Dictionary<Type, IExitableState>
            {
                [typeof(BootstrapState)] = new BootstrapState(this, sceneLoader, allServises),
                [typeof(LoadLevelState)] = new LoadLevelState(this, sceneLoader, loaderCurtain, allServises.Single<IGameFactory>() ),
                [typeof(GameLoopState)] = new GameLoopState(this),
            }; 
        }

        public void Enter<TState>() where TState : class, IState
        {
            IState state = ChangeState<TState>();
            state.Enter();
        }

        public void Enter<TState, TPayLoad>(TPayLoad payLoad) where TState : class, IPayLoadedState<TPayLoad>
        {
            TState state = ChangeState<TState>();
            state.Enter(payLoad);
        }

        private TState ChangeState<TState>() where TState : class, IExitableState
        {
            _activeState?.Exit();

            TState state = GetState<TState>();
            _activeState = state;

            return state;
        }

        private TState GetState<TState>() where TState : class, IExitableState =>
            _states[typeof(TState)] as TState;
    }
}