using System.Collections.Generic;
using Secret.Player.Logic;
using UnityEngine;

namespace Secret.Player.Animations.Logic
{
    public class AnimationChooserDeathHash : MonoBehaviour
    {
        private List<int> _hashs = new List<int>();

        private void Awake()
        {
            AddParameters();
        }

        public int GetRandomDeathHash() => _hashs[GetRandomIndex()];

        private int GetRandomIndex() => Random.Range(0, _hashs.Count - 1);

        private void AddParameters()
        {
            _hashs.Add(PlayerStatic.DeathAHash);
            _hashs.Add(PlayerStatic.DeathBHash);
            _hashs.Add(PlayerStatic.DeathCHash);
            _hashs.Add(PlayerStatic.DeathDHash);
            _hashs.Add(PlayerStatic.DeathEHash);
        }
    }
}