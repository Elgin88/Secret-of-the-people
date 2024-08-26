using System;
using Scripts.StaticData;
using UnityEngine;

namespace Scripts.Enemy
{
    public class AgroZone : MonoBehaviour
    {
        [SerializeField] private SphereCollider _collider;
        [SerializeField] private MonsterStaticData _staticData;

        private float _radius;

        public event Action<Collider> TriggeredEnter;

        public event Action<Collider> TriggeredExit;

        private void Awake()
        {
            SetRadius();
            SetRadiusCollider();
        }

        private void OnTriggerEnter(Collider collider) => TriggeredEnter?.Invoke(collider);

        private void OnTriggerExit(Collider collider) => TriggeredExit?.Invoke(collider);

        private void SetRadius() => _radius = _staticData.AgroRange;

        private void SetRadiusCollider() => _collider.radius = _radius;
    }
}