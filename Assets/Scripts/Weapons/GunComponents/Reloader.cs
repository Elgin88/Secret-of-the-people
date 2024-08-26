using Scripts.CodeBase.Logic;
using UnityEngine;

namespace Scripts.Weapons.GunComponents
{
    public class Reloader : MonoBehaviour
    {
        private bool _isReloading = false;

        public bool IsReloading => _isReloading;

        public void Construct(IGameFactory gameFactory)
        {
        }

        public void Reload()
        {
            _isReloading = true;
        }
    }
}