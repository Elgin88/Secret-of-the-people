using System;
using Scripts.StaticData;
using UnityEngine;

namespace Enemy.Agents.Attack
{
    public class AttackZone : MonoBehaviour
    {
        [SerializeField] private SphereCollider _collider;
        [SerializeField] private MonsterStaticData _staticData;

        private float _radius;

        public Action<Collider> PlayerEnter;

        public Action<Collider> PlayerExit;

        private void Awake()
        {
            SetRadius();
            SetRadiusOfRadius();
        }

        private void OnTriggerEnter(Collider collider) => PlayerEnter?.Invoke(collider);

        private void OnTriggerExit(Collider collider) => PlayerExit?.Invoke(collider);

        private void SetRadius() => _radius = _staticData.AttackRange;

        private void SetRadiusOfRadius() => _collider.radius = _radius;
    }
}