using Screpts.Hero;
using System;
using UnityEngine;

namespace Screpts
{
    public class Trigger : MonoBehaviour
    {
        public event Action<Player> Enter;

        private void OnTriggerEnter(Collider other)
        {
            if(other.TryGetComponent(out Player player))
            {
                Enter?.Invoke(player);
            }
        }
    }
}
