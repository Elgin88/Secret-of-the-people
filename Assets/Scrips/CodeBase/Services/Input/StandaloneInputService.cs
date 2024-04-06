using UnityEngine;

namespace Scripts.CodeBase.Services.Input
{
    internal class StandaloneInputService : InputService
    {
        public override Vector2 Axis
        {
            get
            {
                Vector2 axis = GetAxisFromJoystick();

                if (axis == Vector2.zero)
                {
                    axis = GetAxisFromKeyboard();
                }

                return axis;
            }
        }
    }
}