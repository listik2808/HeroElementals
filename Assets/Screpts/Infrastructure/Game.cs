using Screpts.Hero;
using Screpts.ZonaTreeger;
using System;
using UnityEngine;

namespace Screpts.Infrastructure
{
    public class Game : MonoBehaviour
    {
        [SerializeField] private CameraFollow _cameraFollow;
        [SerializeField] private Player _player;
        [SerializeField] private ChoosingHero _chooseHero;

        private void OnEnable()
        {
            
        }

        private void OnDisable()
        {
            
        }

        private void Start()
        {
            _cameraFollow.Follow(_player.gameObject);
        }

        private void ActivateHeroMove()
        {
            _player.HeroMove.enabled = true;
        }
    }
}
