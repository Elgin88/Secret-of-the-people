using System;
using Scripts.CodeBase.Logic;
using Scripts.PlayerComponents;
using UnityEngine;

namespace Scripts.Weapons
{
    public class GunClipSetter : MonoBehaviour
    {
        private IClip _iCurrentClip;

        public IClip CurrentClip => _iCurrentClip;

        internal void SetClip(IClip clip)
        {
            _iCurrentClip = clip;
        }
    }
}