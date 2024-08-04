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

        public event Action OnExit;

        public void OnEnable()
        {
            _exitButton.onClick.AddListener(Exit);
        }

        private void OnDisable()
        {
            _exitButton.onClick.RemoveListener(Exit);
        }

        private void Exit()
        {
            gameObject.SetActive(false);
            OnExit?.Invoke();
        }
    }
}
