using UnityEngine;

namespace Scripts.Player
{
    public class ShootPointSetter : MonoBehaviour
    {
        [SerializeField] private Transform _shootPoint;

        public Transform ShootPoint => _shootPoint;
    }
}