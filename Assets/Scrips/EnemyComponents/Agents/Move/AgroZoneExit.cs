using System;
using UnityEngine;

namespace Scripts.EnemyComponents
{
    public class AgroZoneExit : MonoBehaviour
    {
        public event Action<Collider> TriggeredExit;

        private void OnTriggerExit(Collider other) => TriggeredExit?.Invoke(other);
    }
}