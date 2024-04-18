using System.Collections;
using CodeBase.Static;
using UnityEngine;

namespace Scripts.InitializeGame
{
    public class InitializeSDK : MonoBehaviour
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        private void Awake()
        {
            Agava.YandexGames.YandexGamesSdk.CallbackLogging = true;
        }

        private IEnumerator Start()
        {
            yield return Agava.YandexGames.YandexGamesSdk.Initialize(LoadNextLevel);
        }

        private void LoadNextLevel()
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(ScenesNames.SceneNameInitialGame);
        }
#endif
    }
}