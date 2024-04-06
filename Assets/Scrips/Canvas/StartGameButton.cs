using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Scripts.Canvas
{
    internal class StartGameButton : CanvasButton
    {
        [SerializeField] private Button _button;

        public override Button Button => _button;

        public override void OnEnable()
        {
            _button.onClick.AddListener(OnButtonClick);
        }

        public override void OnDisable()
        {
            _button.onClick.RemoveListener(OnButtonClick);
        }

        public override void OnButtonClick()
        {
            SceneManager.LoadScene(SceneNames.Level1);
        }
    }
}