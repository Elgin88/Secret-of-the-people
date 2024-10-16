using Secret.Infrastructure.Factory;
using Secret.StaticData;
using Secret.Weapons.Weapons.Gun;
using UnityEngine;

namespace Secret.Weapons.Clips.GunClip
{
    public class GunClipContainer : MonoBehaviour, IClipContainer, IGun
    {
        [SerializeField] private WeaponStaticData _staticData;

        private IGameFactory _gameFactory;

        public void Construct(IGameFactory gameFactory)
        {
            _gameFactory = gameFactory;
        }

        public void Fill()
        {
            Debug.Log("Заполнить Clip");
        }
    }
}