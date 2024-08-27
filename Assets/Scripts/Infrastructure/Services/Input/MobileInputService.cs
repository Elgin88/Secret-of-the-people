﻿using UnityEngine;

namespace Infrastructure.Services.Input
{
    public class MobileInputService : InputService, IInputService
    {
        public override Vector2 Axis => GetMobileAxis().normalized;
    }
}