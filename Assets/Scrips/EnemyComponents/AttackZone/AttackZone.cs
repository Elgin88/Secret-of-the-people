using System;
using UnityEngine;

namespace Scripts.EnemyComponents
{
    public class AttackZone : MonoBehaviour
    {
        public Action<Collider> PlayerEnter;
        public Action<Collider> PlayerExit;

        private void OnTriggerEnter(Collider other)
        {
            PlayerEnter?.Invoke(other);
            Debug.Log("1");
        }

        private void OnTriggerExit(Collider other) => PlayerExit?.Invoke(other);
    }
}