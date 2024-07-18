using System;
using UnityEngine;

namespace Scripts.EnemyComponents
{
    public class AgroZone : MonoBehaviour
    {
        [SerializeField] private SphereCollider _collider;

        private float _radius = 8;

        public event Action<Collider> TriggeredEnter;

        public event Action<Collider> TriggeredExit;

        private void Awake() => SetRadius();

        private void SetRadius() => _collider.radius = _radius;

        private void OnTriggerEnter(Collider collider) => TriggeredEnter?.Invoke(collider);

        private void OnTriggerExit(Collider collider) => TriggeredExit?.Invoke(collider);
    }
}