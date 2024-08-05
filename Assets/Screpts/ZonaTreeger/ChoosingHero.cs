using Screpts.Hero;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Screpts.ZonaTreeger
{
    public class ChoosingHero : MonoBehaviour
    {
        [SerializeField] private List<AvatarPlayer> _heroes = new List<AvatarPlayer>();
        [SerializeField] private Trigger _trigger;
        private Player _player;
        private AvatarPlayer _currentAvatarPlayer;

        public List<AvatarPlayer> ListHeroAvatar => _heroes;

        public event Action OpenPanelHero;
        public event Action StartMovementHero;

        private void OnEnable()
        {
            _trigger.Enter += OpenPlayerPanel;
            StartMovementHero += ActivateMovementHero;
        }

        private void OnDisable()
        {
            _trigger.Enter -= OpenPlayerPanel;
            StartMovementHero -= ActivateMovementHero;
        }

        public void ActivateHeroMove()
        {
            StartMovementHero?.Invoke();
        }

        public void OpenHeroIndex(int number)
        {
            int maxCount = _heroes.Count -1;
            foreach (var player in _heroes) 
            {
                if (_currentAvatarPlayer.Index == player.Index)
                {
                    int indexCurrent = _heroes.IndexOf(_currentAvatarPlayer);
                    _currentAvatarPlayer.gameObject.SetActive(false);
                    if (indexCurrent + number <= maxCount && indexCurrent + number >= 0)
                    {
                        _currentAvatarPlayer = _heroes[indexCurrent + number];
                        _currentAvatarPlayer.gameObject.SetActive(true);
                        break;
                    }
                    else if (indexCurrent + number > maxCount)
                    {
                        _currentAvatarPlayer = _heroes[0];
                        _currentAvatarPlayer.gameObject.SetActive(true);
                        break;
                    }
                    else if (indexCurrent + number < 0)
                    {
                        _currentAvatarPlayer = _heroes[maxCount];
                        _currentAvatarPlayer.gameObject.SetActive(true);
                        break;
                    }
                }
            }
        }

        private void OpenPlayerPanel(Player player)
        {
            _currentAvatarPlayer = _heroes[0];
            _currentAvatarPlayer.gameObject.SetActive(true);
            _player = player;
            _player.MuveStop();
            OpenPanelHero?.Invoke();
        }

        private void ActivateMovementHero()
        {
            _currentAvatarPlayer.gameObject.SetActive(false);
            _player.MuveStart();
        }
    }
}