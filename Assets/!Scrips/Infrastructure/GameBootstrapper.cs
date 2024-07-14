using Agava.YandexGames;
using System;
using System.Collections;
using UnityEngine;

namespace Scripts.CodeBase.Logic
{
    public class GameBootstrapper : MonoBehaviour, ICoroutineRunner
    {
        private Game _game;

        public Game Game => _game;

        private void Awake()
        {
            SetSDKCallbacklogin(true);
            DontDestroyOnLoad(this);
        }

        private IEnumerator Start()
        {
            if (CheckIsEditor(InitializeGame))
            {
                yield break;
            }

            yield return YandexGamesSdk.Initialize(InitializeGame);
        }

        private void InitializeGame()
        {
            _game = new Game(new GameStateMachine(new SceneLoader(this), AllServices.Container));
        }

        private static void SetSDKCallbacklogin(bool status) => YandexGamesSdk.CallbackLogging = status;

        private bool CheckIsEditor(Action onInitializeGame)
        {
            bool isEditor = false;

#if UNITY_EDITOR
            isEditor = true;
            onInitializeGame?.Invoke();
#endif
            return isEditor;
        }
    }
}