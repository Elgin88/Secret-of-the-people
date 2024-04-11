using UnityEngine;

namespace Scripts.CodeBase.Services.Input
{
    public class MobileInputService : InputService
    {
        public override Vector2 Axis => GetAxisFromJoystick();
    }
}