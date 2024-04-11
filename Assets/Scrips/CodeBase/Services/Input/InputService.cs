using UnityEngine;

namespace Scripts.CodeBase.Services.Input
{
    public abstract class InputService : IInputService
    {
        protected string Horizontal = "Horizontal";
        protected string Vertical = "Vertical";

        public abstract Vector2 Axis { get; }

        protected Vector2 GetAxisFromJoystick() => new Vector2(SimpleInput.GetAxis(Horizontal), SimpleInput.GetAxis(Vertical));
        protected Vector2 AxisFromKeyboard() => new Vector2(UnityEngine.Input.GetAxis(Horizontal), UnityEngine.Input.GetAxis(Vertical));
    }
}