using System;
using UnityEngine;

namespace Screpts
{
    public class Trigger : MonoBehaviour
    {
        public event Action Enter;

        private void OnTriggerEnter(Collider other)
        {
            Enter?.Invoke();
        }
    }
}
