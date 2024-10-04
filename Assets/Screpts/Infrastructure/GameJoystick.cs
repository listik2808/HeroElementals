using UnityEngine;

namespace Screpts.Infrastructure
{
    public class GameJoystick : MonoBehaviour
    {
        [SerializeField] private GameObject _joystick;
       

        private void Start()
        {
            TryJoystickDiactivate();
        }

        private void TryJoystickDiactivate()
        {
            if(Application.isEditor)
            _joystick.gameObject.SetActive(false);
        }
    }
}
