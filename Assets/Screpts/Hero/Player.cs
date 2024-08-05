using System;
using UnityEngine;

namespace Screpts.Hero
{
    public class Player : MonoBehaviour 
    {
        [SerializeField] private AvatarPlayer _avatar;
        [SerializeField] private HeroMove _heroMove;

        public HeroMove HeroMove => _heroMove;

        public event Action StopMovement;
        public event Action StartMovement;

        private void OnEnable()
        {
            StopMovement += Stop;
            StartMovement += StartMove;
        }

        private void OnDisable()
        {
            StopMovement -= Stop;
            StartMovement += StartMove;
        }

        public void MuveStop()
        {
            StopMovement?.Invoke();
        }

        public void MuveStart()
        {
            StartMovement?.Invoke();
        }

        private void Stop()
        {
            _heroMove.enabled = false;
        }
        private void StartMove()
        {
            _heroMove.enabled = true;
        }

    }
}
