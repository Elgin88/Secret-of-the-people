using System;
using Scripts.CodeBase.Logic;
using UnityEngine;

namespace Scripts.WeaponsComponents
{
    public class GunClipSetter : MonoBehaviour
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