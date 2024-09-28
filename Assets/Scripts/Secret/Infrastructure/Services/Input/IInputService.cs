using UnityEngine;

namespace Secret.Infrastructure.Services.Input
{
    public interface IInputService : IService
    {
        public Vector2 Axis { get; }
    }
}