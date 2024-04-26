using Scripts.Data;
using Scripts.Services.PersistentProgress;
using Scripts.Services.PersistentProgress.SaveAndLoad;
using Scripts.Static;

namespace Scripts.CodeBase.Infractructure.State
{
    public class LoadProgressState : IState
    {
        private readonly GameStateMashine _gameStateMashine;
        private readonly IPersistentProgressService _persistentProgressService;
        private ISaveAndLoadService _saveLoadService;

        public LoadProgressState(GameStateMashine gameStateMashine, IPersistentProgressService persistentProgressService, ISaveAndLoadService saveAndLoadService)
        {
            _gameStateMashine = gameStateMashine;
            _persistentProgressService = persistentProgressService;
        }

        public void Enter()
        {
            LoadProgressOrInitNew();

            _gameStateMashine.Enter<LoadLevelState, string>(_persistentProgressService.PlayerProgress.WorldData.PositionOnLevel.LevelName);
        }

        public void Exit()
        {
        }

        private void LoadProgressOrInitNew()
        {
            _persistentProgressService.PlayerProgress =
                _saveLoadService.LoadProgress()
                ?? NewProgress();
        }

        private PlayerGameProgress NewProgress() => new PlayerGameProgress(ScenesNames.Level1);
    }
}