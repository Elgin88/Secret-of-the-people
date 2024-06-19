using System;
using UnityEngine;

namespace Scripts.EnemyComponents
{
    public class AttackZone : MonoBehaviour
    {
        public Action<Collider> InAttackZoneEnter;
        public Action<Collider> InAttackZoneExit;

        private void OnTriggerEnter(Collider other) => InAttackZoneEnter?.Invoke(other);
        private void OnTriggerExit(Collider other) => InAttackZoneExit?.Invoke(other);
    }
}