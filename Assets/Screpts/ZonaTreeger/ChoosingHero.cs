using Screpts.Hero;
using Screpts.UI;
using Screpts.Wallet;
using System;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

namespace Screpts.ZonaTreeger
{
    public class ChoosingHero : MonoBehaviour
    {
        [SerializeField] private List<AvatarPlayer> _heroes = new List<AvatarPlayer>();
        [SerializeField] private Trigger _trigger;
        [SerializeField] private PayModelHero _payModelHero;
        [SerializeField] private ShellChangeButton _shellChangeButton;
        [SerializeField] private Money _money;
        [SerializeField] private GameObject _container;

        private Player _player;
        private AvatarPlayer _currentAvatarPlayer;

        public Player CurrentPlayer => _player;

        public event Action OpenPanelHero;

        private void OnEnable()
        {
            _trigger.Enter += OpenPlayerPanel;
        }

        private void OnDisable()
        {
            _trigger.Enter -= OpenPlayerPanel;
        }

        public void CloseVizibleBody()
        {
            _currentAvatarPlayer.gameObject.SetActive(false);
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
                        ActivateButton(_currentAvatarPlayer);
                        _currentAvatarPlayer.gameObject.SetActive(true);
                        break;
                    }
                    else if (indexCurrent + number > maxCount)
                    {
                        _currentAvatarPlayer = _heroes[0];
                        ActivateButton(_currentAvatarPlayer);
                        _currentAvatarPlayer.gameObject.SetActive(true);
                        break;
                    }
                    else if (indexCurrent + number < 0)
                    {
                        _currentAvatarPlayer = _heroes[maxCount];
                        ActivateButton(_currentAvatarPlayer);
                        _currentAvatarPlayer.gameObject.SetActive(true);
                        break;
                    }
                }
            }
        }

        private void OpenPlayerPanel(Player player)
        {
            _currentAvatarPlayer = _heroes[0];
            ActivateButton(_currentAvatarPlayer);
            _currentAvatarPlayer.gameObject.SetActive(true);
            _player = player;
            _player.MuveStop();
            OpenPanelHero?.Invoke();
        }


        private void ActivateButton(AvatarPlayer avatarPlayer)
        {
            if (avatarPlayer.IsPurchased == false)
            {
                if(_shellChangeButton.enabled == true)
                {
                    _shellChangeButton.ChangingBody -= SetBody;
                    _shellChangeButton.enabled = false;
                }
                if (_payModelHero.enabled == false)
                {
                    _payModelHero.enabled = true;
                    _payModelHero.PayBodyHero += PayNewBody;
                }
                _payModelHero.ShowPrice(_currentAvatarPlayer.Price,_money.Coins);
            }
            else
            {
                if(_payModelHero.enabled == true)
                {
                    _payModelHero.PayBodyHero -= PayNewBody;
                    _payModelHero.enabled = false;
                }
                if (_shellChangeButton.enabled == false)
                {
                    _shellChangeButton.enabled = true;
                    _shellChangeButton.BodyChangeButton.interactable = true;
                    _shellChangeButton.ChangingBody += SetBody;
                }
                
            }
        }

        private void SetBody()
        {
            AvatarPlayer avatar = _player.Avatar;
            Vector3 pointPositionPlayer = _player.Avatar.transform.position;
            Vector3 pointPositionModel = _currentAvatarPlayer.transform.position;
            _currentAvatarPlayer.transform.SetParent(null);
            _currentAvatarPlayer.transform.SetParent(_player.Container.transform);
            _player.Avatar.transform.SetParent(null);
            _player.Avatar.transform.SetParent(_container.transform);
            _player.Avatar.transform.position = pointPositionModel;
            _currentAvatarPlayer.transform.position = pointPositionPlayer;

            _player.SetAvatarComponent(_currentAvatarPlayer);
            for (int i = 0; i < _heroes.Count; i++)
            {
                if (_heroes[i] == _currentAvatarPlayer)
                {
                    _heroes[i] = avatar;
                }
            }
            ArrangeIndex();
            _currentAvatarPlayer = avatar;
        }

        private void PayNewBody(float price)
        {
            _money.Pay(price);
            _currentAvatarPlayer.ModelIsPurchased();
            ActivateButton(_currentAvatarPlayer);
        }

        private void ArrangeIndex()
        {
            for (int i = 0; i < _heroes.Count; i++)
            {
                for (int j = i+1; j < _heroes.Count; j++)
                {
                    if (_heroes[i].Index > _heroes[j].Index)
                    {
                        AvatarPlayer temp = _heroes[i];
                        _heroes[i] = _heroes[j];
                        _heroes[j] = temp;
                    }
                }
            }
        }
    }
}