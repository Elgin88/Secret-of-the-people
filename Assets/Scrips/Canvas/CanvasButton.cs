using UnityEngine;
using UnityEngine.UI;

namespace Scripts.Canvas
{
    internal abstract class CanvasButton : MonoBehaviour
    {
        public abstract Button Button { get; }

        public abstract void OnButtonClick();
        public abstract void OnDisable();
        public abstract void OnEnable();
    }
}