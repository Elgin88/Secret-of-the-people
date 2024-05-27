using UnityEngine;

namespace Scripts.CodeBase.Infractructure
{
    public abstract class InputService : IInputService
    {
        private const string _horizontal = "Horizontal";
        private const string _vertical = "Vertical";

        public abstract Vector2 Axis { get; }

        protected Vector2 GetMobileAxis() => new Vector2(SimpleInput.GetAxis(_horizontal), SimpleInput.GetAxis(_vertical));

        protected Vector2 GetUnityAxis() => new Vector2(Input.GetAxis(_horizontal), Input.GetAxis(_vertical));
    }
}