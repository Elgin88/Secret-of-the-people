using Scripts.Static;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scripts.Logic
{
    public class LoaderInitialScene : MonoBehaviour
    {
        private void Start()
        {
            SceneManager.LoadScene(ScenesNames.InitialGame);
        }
    }
}