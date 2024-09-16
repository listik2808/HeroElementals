using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Screpts.UI
{
    public class PayModelHero : MonoBehaviour
    {
        [SerializeField] private Button _buttonPay;
        [SerializeField] private TMP_Text _textButtonPay;
        private float _price;

        public Button ButtonPay => _buttonPay;

        public event Action<float> PayBodyHero;

        private void OnEnable()
        {
            _buttonPay.onClick.AddListener(PayModel);
        }

        private void OnDisable()
        {
            _buttonPay.onClick.RemoveListener(PayModel);
        }
        public void ShowPrice(float price,float coins)
        {
            _price = price;
            _textButtonPay.text = "Купить\n" + price;
            if (coins >= price)
                _buttonPay.interactable = true;
            else
                _buttonPay.interactable = false;
        }

        private void PayModel()
        {
            PayBodyHero?.Invoke(_price);
        }
    }
}
