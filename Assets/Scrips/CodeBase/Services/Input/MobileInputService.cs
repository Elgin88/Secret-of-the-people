using UnityEngine;

namespace Scripts.CodeBase.Services.Input
{
    internal class MobileInputService : InputService
    {
        public override Vector2 Axis => GetAxisFromJoystick();
    }
}