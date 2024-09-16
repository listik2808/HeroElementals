using Screpts.UI;
using Screpts.ZonaTreeger;
using UnityEngine;

namespace Screpts.Infrastructure
{
    public class HeroPanelListener : MonoBehaviour
    {
        [SerializeField] private CanvasPanelHero _panelHero;
        [SerializeField] private ChoosingHero _choiceHero;

        public void OnEnable()
        {
            _choiceHero.OpenPanelHero += OpenCanvasPanelHero;
            _panelHero.ExitButton.onClick.AddListener(ClosePanelhero);
            _panelHero.NextHero.onClick.AddListener(GoNextHero);
            _panelHero.PreviousHero.onClick.AddListener(GoPreviousHero);
        }

        public void OnDisable()
        {
            _choiceHero.OpenPanelHero -= OpenCanvasPanelHero;
            _panelHero.ExitButton.onClick.RemoveListener(ClosePanelhero);
            _panelHero.NextHero.onClick.RemoveListener(GoNextHero);
            _panelHero.PreviousHero.onClick.AddListener(GoPreviousHero);
        }

        private void OpenCanvasPanelHero()
        {
            _panelHero.gameObject.SetActive(true);
        }

        private void ClosePanelhero()
        {
            _choiceHero.CurrentPlayer.MuveStart();
            _choiceHero.CloseVizibleBody();
            _panelHero.gameObject.SetActive(false);
        }

        private void GoNextHero()
        {
            _choiceHero.OpenHeroIndex(1);
        }

        private void GoPreviousHero()
        {
            _choiceHero.OpenHeroIndex(-1);
        }
    }
}
