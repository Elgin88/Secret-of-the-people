using UnityEngine;

namespace Scripts.Bullets
{
    public abstract class Bullet : MonoBehaviour
    {
        public abstract float Speed { get; }
    }
}