using System;
using Scripts.CodeBase.Logic;
using UnityEngine;

namespace Scripts.WeaponsComponents.GunComponents
{
    public class ClipSetter : MonoBehaviour
    {
        private IClip _iCurrentClip;

        public IClip CurrentClip => _iCurrentClip;

        public void Contruct(IGameFactory gameFactory)
        {
        }

        public void SetClip(IClip clip)
        {
            _iCurrentClip = clip;
        }
    }
}