using Infrastructure.Services;
using UnityEngine;

namespace Scripts.CodeBase.Logic
{
    public interface IInputService : IService
    {
        public Vector2 Axis { get; }
    }
}