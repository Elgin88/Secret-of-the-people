using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Player
{
    public class ChooserDeathHash : MonoBehaviour
    {
        private List<int> _parametrs = new List<int>();

        public int GetRandomDeathHash()
        {
            AddParametrs();

            return _parametrs[GetRandomIndex()];
        }

        private int GetRandomIndex() => Random.Range(0, _parametrs.Count - 1);

        private void AddParametrs()
        {
            _parametrs.Add(Static.DeathAHash);
            _parametrs.Add(Static.DeathBHash);
            _parametrs.Add(Static.DeathCHash);
            _parametrs.Add(Static.DeathDHash);
            _parametrs.Add(Static.DeathEHash);
        }
    }
}