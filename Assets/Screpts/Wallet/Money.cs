using UnityEngine;

namespace Screpts.Wallet
{
    public class Money : MonoBehaviour
    {
        private float _coins = 0;

        public float Coins { 
            get 
            {
                return _coins; 
            }
        }

        public void Pay( float price)
        {
            _coins -= price;
        }
    }
}
