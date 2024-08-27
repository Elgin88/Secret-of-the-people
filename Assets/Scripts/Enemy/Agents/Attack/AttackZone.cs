using System;
using Scripts.StaticData;
using UnityEngine;

namespace Enemy.Agents.Attack
{
    public class AttackZone : MonoBehaviour
    {
        [SerializeField] private MonsterStaticData _staticData;
        [SerializeField] private SphereCollider _collider;

        private float _attackRange;

        public Action<Collider> PlayerEnter;

        public Action<Collider> PlayerExit;

        private void Awake()
        {
            SetRadius();
            SetRadiusOfRadius();
        }

        private void OnTriggerEnter(Collider player) => PlayerEnter?.Invoke(player);
        private void OnTriggerExit(Collider player) => PlayerExit?.Invoke(player);
        private void SetRadius() => _attackRange = _staticData.AttackRange;
        private void SetRadiusOfRadius() => _collider.radius = _attackRange;
    }
}