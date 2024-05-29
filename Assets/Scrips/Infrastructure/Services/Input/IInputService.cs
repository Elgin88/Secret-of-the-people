using UnityEngine;

namespace Scripts.CodeBase.Infractructure
{
    public interface IInputService : IService
    {
        public Vector2 Axis { get; }
    }
}