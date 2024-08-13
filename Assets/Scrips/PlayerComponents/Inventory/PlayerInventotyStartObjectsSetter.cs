using Scripts.CodeBase.Logic;
using Scripts.StaticData;
using Scripts.Weapons;
using System;
using UnityEngine;

namespace Scripts.PlayerComponents
{
    public class PlayerInventotyStartObjectsSetter : MonoBehaviour
    {
        [SerializeField] private PlayerStaticData _staticData;

        private int _startGunClipCount;

        public void Construct()
        {
            SetStartClipCount();
        }

        private void SetStartClipCount() => _startGunClipCount = _staticData.StartGunClipsCount;
    }
}