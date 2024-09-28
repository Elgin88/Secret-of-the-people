using UnityEngine;

namespace Secret.Infrastructure.Services.Input
{
    public class MobileInputService : InputService, IInputService
    {
        public override Vector2 Axis => GetMobileAxis().normalized;
    }
}