using Infrastructure.Services.Factory;
using UnityEngine;
using Weapons.Interfaces;

namespace Weapons.GunComponents
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