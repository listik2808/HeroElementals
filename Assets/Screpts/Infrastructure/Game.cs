using Screpts.Hero;
using UnityEngine;

namespace Screpts.Infrastructure
{
    public class Game : MonoBehaviour
    {
        [SerializeField] private CameraFollow _cameraFollow;
        [SerializeField] private HeroMove _heroMove;

        private void Start()
        {
            _cameraFollow.Follow(_heroMove.gameObject);
        }

    }
}
