using System.Collections.Generic;
using Secret.Infrastructure.Factory;
using Secret.Weapons.Clips;
using Secret.Weapons.Weapons;
using UnityEngine;

namespace Secret.Player.Inventory
{
    public class Container : MonoBehaviour, IContainer
    {
        private List<IWeapon> _weapons = new List<IWeapon>();
        private List<IClip> _clips = new List<IClip>();
        private IGameFactory _gameFactory;

        public void Construct(IGameFactory gameFactory)
        {
            _gameFactory = gameFactory;
        }

        public void AddGun()
        {
            _weapons.Add(_gameFactory.CreateGun().GetComponent<IWeapon>());
        }

        public void AddGunClips()
        {
            _clips.Add(_gameFactory.CreateGunClip().GetComponent<IClip>());
        }

        public void AddBulletsInAllClips()
        {
            foreach (IClip clip in _clips)
            {
                clip.ClipContainer.Fill();
            }
        }
    }
}