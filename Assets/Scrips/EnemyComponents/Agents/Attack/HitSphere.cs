using Scripts.StaticData;
using UnityEngine;

namespace Scripts.EnemyComponents
{
    public class HitSphere : MonoBehaviour
    {
        [SerializeField] private MonsterStaticData _staticData;

        private float _radiusOfHitSphere;

        public float RadiusOfHitSphere => _radiusOfHitSphere;

        private void Awake() => _radiusOfHitSphere = _staticData.RadiusOfHitSphere;
    }
}