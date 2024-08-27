using StaticData;
using UnityEngine;

namespace Enemy.Agents.Attack
{
    public class HitSphere : MonoBehaviour
    {
        [SerializeField] private MonsterStaticData _staticData;

        public float Radius { get; private set; }

        private void Awake() => Radius = _staticData.RadiusOfHitSphere;
    }
}