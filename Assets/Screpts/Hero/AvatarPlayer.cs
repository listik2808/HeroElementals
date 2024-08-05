using UnityEngine;

namespace Screpts.Hero
{
    public class AvatarPlayer : MonoBehaviour
    {
        [SerializeField] private GameObject _container;
        [SerializeField] private int _index;

        public int Index => _index;
        public GameObject Container => _container;
    }
}
