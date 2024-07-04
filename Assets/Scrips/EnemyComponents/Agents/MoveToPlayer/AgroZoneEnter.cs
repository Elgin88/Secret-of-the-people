using System;
using UnityEngine;

namespace Scripts.EnemyComponents
{
    public class AgroZoneEnter : MonoBehaviour
    {
        public event Action<Collider> TriggeredEnter;

        private void OnTriggerEnter(Collider other) => TriggeredEnter?.Invoke(other);
    }
}