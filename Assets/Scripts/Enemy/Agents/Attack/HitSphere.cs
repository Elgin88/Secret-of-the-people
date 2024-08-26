using Scripts.StaticData;
using UnityEngine;

namespace Enemy.Agents.Attack
{
    public class HitSphere : MonoBehaviour
    {
        [SerializeField] private MonsterStaticData _staticData;

        private float _radius;

        public float Radius => _radius;

        private void Awake() => _radius = _staticData.RadiusOfHitSphere;
    }
}