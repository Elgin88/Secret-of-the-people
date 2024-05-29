using UnityEngine;

namespace Scripts.CodeBase.Infractructure
{
    public class MobileInputService : InputService, IInputService
    {
        public override Vector2 Axis => GetMobileAxis().normalized;
    }
}