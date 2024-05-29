using UnityEngine;

namespace Scripts.CodeBase.Infractructure
{
    public abstract class InputService : IInputService
    {
        private const string _horizontal = "Horizontal";
        private const string _vertical = "Vertical";

        public abstract Vector2 Axis { get; }

        protected Vector2 GetMobileAxis() => new Vector2(SimpleInput.GetAxisRaw(_horizontal), SimpleInput.GetAxisRaw(_vertical));

        protected Vector2 GetUnityAxis() => new Vector2(Input.GetAxisRaw(_horizontal), Input.GetAxisRaw(_vertical));
    }
}