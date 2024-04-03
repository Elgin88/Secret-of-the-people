using UnityEngine;

namespace CodeBase.Services.Input
{
    internal class MobileInputService : InputService
    {
        public override Vector2 Axis => GetSimpleInputAxix();
    }
}