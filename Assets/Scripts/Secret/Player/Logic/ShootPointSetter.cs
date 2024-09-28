using UnityEngine;

namespace Secret.Player.Logic
{
    public class ShootPointSetter : MonoBehaviour
    {
        [SerializeField] private Transform _shootPoint;

        public Transform ShootPoint => _shootPoint;
    }
}