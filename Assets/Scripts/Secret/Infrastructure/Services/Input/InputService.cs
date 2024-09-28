using UnityEngine;

namespace Secret.Infrastructure.Services.Input
{
    public abstract class InputService : IInputService
    {
        private const string _horizontal = "Horizontal";
        private const string _vertical = "Vertical";

        public abstract Vector2 Axis { get; }

        protected Vector2 GetMobileAxis() => new Vector2(SimpleInput.GetAxisRaw(_horizontal), SimpleInput.GetAxisRaw(_vertical));

        protected Vector2 GetUnityAxis() => new Vector2(UnityEngine.Input.GetAxisRaw(_horizontal), UnityEngine.Input.GetAxisRaw(_vertical));
    }
}