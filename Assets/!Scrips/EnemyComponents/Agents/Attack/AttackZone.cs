using System;
using UnityEngine;

namespace Scripts.EnemyComponents
{
    public class AttackZone : MonoBehaviour
    {
        [SerializeField] private SphereCollider _collider;

        private float _radius = 1;

        public Action<Collider> IsPlayerEnter;

        public Action<Collider> IsPlayerExit;

        private void Awake() => SetRadius();

        private void SetRadius() => _collider.radius = _radius;

        private void OnTriggerEnter(Collider collider) => IsPlayerEnter?.Invoke(collider);

        private void OnTriggerExit(Collider collider) => IsPlayerExit?.Invoke(collider);
    }
}