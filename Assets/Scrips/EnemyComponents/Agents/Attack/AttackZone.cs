using System;
using Scripts.StaticData;
using UnityEngine;

namespace Scripts.EnemyComponents
{
    public class AttackZone : MonoBehaviour
    {
        [SerializeField] private SphereCollider _collider;
        [SerializeField] private MonsterStaticData _staticData;

        private float _radius;

        public Action<Collider> IsPlayerEnter;

        public Action<Collider> IsPlayerExit;

        private void Awake()
        {
            SetRadius();
            SetRadiusOfRadius();
        }

        private void OnTriggerEnter(Collider collider) => IsPlayerEnter?.Invoke(collider);

        private void OnTriggerExit(Collider collider) => IsPlayerExit?.Invoke(collider);

        private void SetRadius() => _radius = _staticData.AttackRange;

        private void SetRadiusOfRadius() => _collider.radius = _radius;
    }
}