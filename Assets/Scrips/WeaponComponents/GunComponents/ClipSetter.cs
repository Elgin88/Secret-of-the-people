﻿using System;
using Scripts.CodeBase.Logic;
using UnityEngine;

namespace Scripts.Weapons.GunComponents
{
    public class ClipSetter : MonoBehaviour
    {
        private IClip _iCurrentClip;

        public IClip CurrentClip => _iCurrentClip;

        public void Contruct(IGameFactory gameFactory)
        {
        }

        public void SetCurrentClip(IClip clip)
        {
            _iCurrentClip = clip;
        }
    }
}