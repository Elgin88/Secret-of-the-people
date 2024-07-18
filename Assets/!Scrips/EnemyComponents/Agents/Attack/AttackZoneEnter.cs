using System;
using UnityEngine;

namespace Scripts.EnemyComponents
{
    public class AttackZoneEnter : MonoBehaviour
    {
        [SerializeField] private SphereCollider _collider;

        private float _radius = 1;

        public Action<Collider> IsPlayerEnter;

        public float Radius => _radius;

        private void Awake()
        {
            SetRadius();
        }

        private void OnTriggerEnter(Collider collider)
        {
            IsPlayerEnter?.Invoke(collider);

            Debug.Log("Enter");
        }

        private void SetRadius() => _collider.radius = _radius;
    }
}