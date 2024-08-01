using UnityEngine;

namespace Scripts.Weapons
{
    public abstract class Bullet : MonoBehaviour
    {
        public abstract float StartSpeed { get; }
    }
}