using UnityEngine;

namespace Scripts.EnemyComponents
{
    public class HitArea : MonoBehaviour
    {
        private const float _radiusOfHitArea = 0.8f;

        public float RadiusOfHitArea => _radiusOfHitArea;
    }
}