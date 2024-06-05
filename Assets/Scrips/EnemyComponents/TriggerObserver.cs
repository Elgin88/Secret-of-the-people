using System;
using UnityEngine;

namespace Scripts.EnemyComponents
{
    public class TriggerObserver : MonoBehaviour
    {
        public event Action<Collider> TriggeredEnter;
        public event Action<Collider> TriggeredExit;

        private void OnTriggerEnter(Collider other) => TriggeredEnter?.Invoke(other);

        private void OnTriggerExit(Collider other) => TriggeredExit?.Invoke(other);
    }
}