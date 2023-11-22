using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(StartGameButton))]

public class StartGameButton : MonoBehaviour
{
    private Button _startGameButton;

    private void Start()
    {
        _startGameButton = GetComponent<Button>();

        _startGameButton.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _startGameButton.onClick.RemoveListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        SceneManager.LoadScene(StaticSceneNames.Level1);
    }
}