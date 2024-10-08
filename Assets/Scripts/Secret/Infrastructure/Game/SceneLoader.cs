using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Secret.Infrastructure
{
    public class SceneLoader
    {
        private ICoroutineRunner _coroutineRunner;

        public SceneLoader(ICoroutineRunner coroutineRunner)
        {
            _coroutineRunner = coroutineRunner;
        }

        public void Load(string sceneName, Action onLoaded)
        {
            _coroutineRunner.StartCoroutine(LoadingScene(sceneName, onLoaded));
        }

        private IEnumerator LoadingScene(string sceneName, Action onLoaded = null)
        {
            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName);

            while (!asyncOperation.isDone)
            {
                yield return null;
            }

            onLoaded?.Invoke();
        }
    }
}