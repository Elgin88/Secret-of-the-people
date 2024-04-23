using Scripts.Infractructure.Services;
using UnityEngine;

namespace Scripts.Services.Input
{
    public interface IInputService : IService
    {
        public Vector2 Axis { get; }
    }
}