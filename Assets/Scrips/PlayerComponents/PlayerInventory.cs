using System.Collections.Generic;
using Scripts.CodeBase.Logic;
using Scripts.StaticData;
using Scripts.Weapons;
using UnityEngine;

namespace Scripts.PlayerComponents
{
    public class PlayerInventory : MonoBehaviour
    {
        [SerializeField] private PlayerChooserWeapon _playerChooserWeapon;
        [SerializeField] private PlayerStaticData _staticData;

        private IGameFactory _iGameFactory;
        private List<GameObject> _weapons = new List<GameObject>();
        private List<GameObject> _clips = new List<GameObject>();
        private GameObject _gun;
        private int _startGunClipCount;

        public void Construct(IGameFactory iGameFactory)
        {
            SetIGameFactory(iGameFactory);

            CreateGun();
            AddGunToInventory();

            SetStartClipsCount();
            AddClipsToInventory();

            SetStartWeapon(GetGun());
        }

        private void SetIGameFactory(IGameFactory iGameFactory) => _iGameFactory = iGameFactory;

        private void AddGunToInventory() => _weapons.Add(_gun);

        private void CreateGun() => _gun = _iGameFactory.CreateGun();

        private void SetStartClipsCount() => _startGunClipCount = _staticData.StartClipsCount;

        private void SetStartWeapon(IWeapon weapon) => _playerChooserWeapon.SetCurrentWeapon(weapon);

        private IWeapon GetGun() => _gun.GetComponent<IWeapon>();

        private void AddClipsToInventory()
        {
            for (int i = 0; i < _startGunClipCount; i++)
            {
                GameObject clip = _iGameFactory.CreateGunClip();
                clip.GetComponent<GunClip>().Construct(_iGameFactory);
                _clips.Add(clip);
            }
        }

        public GameObject GetWeaponGun()
        {
            foreach (var weapon in _weapons)
            {
                if (weapon.GetComponent<Gun>() != null)
                {
                    return weapon;
                }
            }

            return null;
        }
    }
}