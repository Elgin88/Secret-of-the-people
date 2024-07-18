using System;
using UnityEngine;

namespace Scripts.EnemyComponents
{
    public class AttackZoneExit : MonoBehaviour
    {
        [SerializeField] private SphereCollider _collider;

        private float _radius = 1.05f;

        public Action<Collider> IsPlayerExit;

        private void Awake()
        {
            SetRadiusCollider();
        }

        private void OnTriggerExit(Collider collider) => IsPlayerExit?.Invoke(collider);
        private void SetRadiusCollider() => _collider.radius = _radius;
    }
}