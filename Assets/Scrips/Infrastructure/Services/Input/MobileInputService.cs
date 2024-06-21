using UnityEngine;

namespace Scripts.CodeBase.Logic
{
    public class MobileInputService : InputService, IInputService
    {
        public override Vector2 Axis => GetMobileAxis().normalized;
    }
}