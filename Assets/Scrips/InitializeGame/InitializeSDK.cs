using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InitializeSDK : MonoBehaviour
{
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
        SceneManager.LoadScene(SceneNames.Level1);
    }
}