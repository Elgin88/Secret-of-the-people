using UnityEngine;

namespace Scripts.InitializeGame
{
    public class GameReady : MonoBehaviour
    {
        private void Start()
        {
#if UNITY_WEBGL && !UNITY_EDITOR
            Agava.YandexGames.YandexGamesSdk.GameReady();
#endif
        }
    }
}