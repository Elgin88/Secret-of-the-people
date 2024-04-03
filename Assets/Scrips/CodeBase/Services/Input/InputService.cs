using UnityEngine;

namespace CodeBase.Services.Input
{
    internal abstract class InputService : IInputService
    {
        protected string Horizontal = "Horizontal";
        protected string Vertical = "Vertical";

        public abstract Vector2 Axis { get; }

        protected Vector2 GetSimpleInputAxix() => new Vector2(SimpleInput.GetAxis(Horizontal), SimpleInput.GetAxis(Vertical));
    }
}