using Scripts.CodeBase.Logic;
using Scripts.PlayerComponents;
using UnityEngine;

namespace Scripts.Weapons
{
    public class GunClipSetter : MonoBehaviour
    {
        private IGameFactory _iGameFactory;

        private IClip _iCurrentClip;

        public IClip ICurrentClip => _iCurrentClip;

        public void Construct(IGameFactory iGameFactory)
        {
            _iGameFactory = iGameFactory;
        }
        
        public void SetICurrentClip()
        {
            _iCurrentClip = _iGameFactory.Player.GetComponent<PlayerInventory>().GetGunClip();
        }

        private void Update()
        {
            Debug.Log(_iCurrentClip);
        }
    }
}