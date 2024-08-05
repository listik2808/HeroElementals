using System;
using UnityEngine;

namespace Screpts.PortalZona
{
    public class Portal : MonoBehaviour
    {
        [SerializeField] private string _nameScene;

        public event Action<string> LoadScene;

        private void OnTriggerEnter(Collider other)
        {
            LoadScene?.Invoke(_nameScene);
        }
    }
}