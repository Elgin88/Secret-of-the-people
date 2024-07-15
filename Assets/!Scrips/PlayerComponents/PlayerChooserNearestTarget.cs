using Scripts.Static;
using UnityEngine;

namespace Scripts.PlayerComponents
{
    public class PlayerChooserNearestTarget : MonoBehaviour
    {
        private const int _radius = 3;
        private Collider[] _results = new Collider[10];
        private int _layerMask;

        private void Awake()
        {
            _layerMask = 1 << StaticLayersNames.Enemy;
        }

        public void FixedUpdate()
        {
            Debug.Log("Дописать выбор цели");

            int countOfEnemy = Physics.OverlapSphereNonAlloc(transform.position, _radius, _results, _layerMask);

            Debug.Log(countOfEnemy);

            if (countOfEnemy == 0)
            {
                _results = new Collider[10];
            }
        }

    }
}