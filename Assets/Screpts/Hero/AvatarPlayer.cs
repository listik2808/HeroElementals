using UnityEngine;

namespace Screpts.Hero
{
    public class AvatarPlayer : MonoBehaviour
    {
        [SerializeField] private int _index;
        [SerializeField] private float _prce;
        private bool _isPurchased = false;

        public int Index => _index;
        public bool IsPurchased => _isPurchased;
        public float Price => _prce;

        public void ModelIsPurchased()
        {
            _isPurchased = true;
        }
    }
}
