using System;
using Scripts.CodeBase.Logic;
using UnityEngine;

namespace Scripts.WeaponsComponents
{
    public class GunReloader : MonoBehaviour
    {
        private bool _isReloading;

        public bool IsReloading;

        public void Construct(IGameFactory gameFactory)
        {
        }

        public void Reload()
        {
            Debug.Log("Reload");
        }
    }
}