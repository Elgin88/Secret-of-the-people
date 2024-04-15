using System.Collections;
using UnityEngine;

namespace Scripts.Logic
{
    public class LoaderCurtain : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _canvasGroup;

        private const float _stepAlpha = 0.03f;
        private const float _delay = 0.1f;
        private WaitForSeconds _delayWFS;

        private void Awake()
        {
            _delayWFS = new WaitForSeconds(_delay);
            DontDestroyOnLoad(this);
        }

        public void Show()
        {
            gameObject.SetActive(true);
            _canvasGroup.alpha = 1;
        }

        public void Hide() => StartCoroutine(FadeIn());

        public IEnumerator FadeIn()
        {
            while (_canvasGroup.alpha > 0)
            {
                _canvasGroup.alpha -= _stepAlpha;
                yield return _delayWFS;
            }

            gameObject.SetActive(false);
        }
    }
}