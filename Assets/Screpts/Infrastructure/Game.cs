using Screpts.Hero;
using Screpts.UI;
using System;
using UnityEngine;

namespace Screpts.Infrastructure
{
    public class Game : MonoBehaviour
    {
        [SerializeField] private CameraFollow _cameraFollow;
        [SerializeField] private HeroMove _heroMove;
        [SerializeField] private Trigger _trigger;
        [SerializeField] private CanvasPanelHero _canvasPanelHero;

        private void OnEnable()
        {
            _trigger.Enter += HeroSelectionPanel;
            _canvasPanelHero.OnExit += ActivateHeroMove;
        }

        private void OnDisable()
        {
            _trigger.Enter -= HeroSelectionPanel;
            _canvasPanelHero.OnExit -= ActivateHeroMove;
        }

        private void Start()
        {
            _cameraFollow.Follow(_heroMove.gameObject);
        }

        private void HeroSelectionPanel()
        {
            _heroMove.enabled = false;
            _canvasPanelHero.gameObject.SetActive(true);
        }

        private void ActivateHeroMove()
        {
            _heroMove.enabled = true;
        }
    }
}
