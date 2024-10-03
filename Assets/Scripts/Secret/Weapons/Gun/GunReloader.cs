using Secret.Infrastructure.Services.Factory;
using Secret.Player.Interfaces;
using Secret.Weapons.Interfaces;
using UnityEngine;

namespace Secret.Weapons.Gun
{
    public class GunReloader : MonoBehaviour
    {
        [SerializeField] private GunContainer _gunContainer;

        private IGameFactory _gameFactory;

        public void Construct(IGameFactory gameFactory)
        {
            _gameFactory = gameFactory;
        }

        public void Reload()
        {
            _gunContainer.SetCurrentClip(GetClip());
        }

        private IClip GetClip() => _gameFactory.Player.GetComponent<IPlayerWeaponContainer>().GetClip();
    }
}