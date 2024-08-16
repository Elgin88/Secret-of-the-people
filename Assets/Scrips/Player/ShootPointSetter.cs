using UnityEngine;

namespace Scripts.PlayerComponents
{
    public class ShootPointSetter : MonoBehaviour
    {
        [SerializeField] private Transform _shootPoint;

        public Transform ShootPoint => _shootPoint;
    }
}