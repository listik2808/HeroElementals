using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Screpts.UI
{
    public class ShellChangeButton : MonoBehaviour
    {
        [SerializeField] private Button _bodyChangeButton;
        [SerializeField] private TMP_Text _textButtonPay;

        public Button BodyChangeButton => _bodyChangeButton;

        public event Action ChangingBody;

        private void OnEnable()
        {
            _bodyChangeButton.onClick.AddListener(ChangeShell);
            ShowTextButton();
        }

        private void OnDisable()
        {
            _bodyChangeButton.onClick.RemoveListener(ChangeShell);
        }

        private void ShowTextButton()
        {
            _textButtonPay.text = "Сменить оболочку";
        }

        private void ChangeShell()
        {
            ChangingBody?.Invoke();
        }
    }
}
