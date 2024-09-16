using System;
using UnityEngine;

namespace Screpts.Hero
{
    public class Player : MonoBehaviour 
    {
        [SerializeField] private AvatarPlayer _avatar;
        [SerializeField] private HeroMove _heroMove;
        [SerializeField] private GameObject _container;

        public GameObject Container => _container;
        public HeroMove HeroMove => _heroMove;
        public AvatarPlayer Avatar => _avatar;

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

        private void Start()
        {
            _avatar.ModelIsPurchased();
        }

        public void SetAvatarComponent(AvatarPlayer avatar)
        {
            _avatar = avatar;
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
