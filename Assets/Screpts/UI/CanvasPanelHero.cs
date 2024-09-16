using Screpts.Hero;
using Screpts.ZonaTreeger;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Screpts.UI
{
    public class CanvasPanelHero :MonoBehaviour
    {
        [SerializeField] private TMP_Text _nameHero;
        [SerializeField] private TMP_Text _valuePower;
        [SerializeField] private TMP_Text _valueWisdom;
        [SerializeField] private TMP_Text _valueHp;
        [SerializeField] private TMP_Text _valueMp;
        [SerializeField] private Button _exitButton;
        [SerializeField] private Button _nextHero;
        [SerializeField] private Button _previousHero;

        public Button ExitButton => _exitButton;
        public Button PreviousHero => _previousHero;
        public Button NextHero => _nextHero;
    }
}
