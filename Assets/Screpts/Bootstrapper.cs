using Screpts.Services.Input;
using SimpleInputNamespace;
using UnityEngine;

namespace Screpts
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private GameObject _joystick;
        public static IInputServices InputServices;
        private bool _isMobile = false;

        public Bootstrapper()
        {
            RegisterInputService();
        }

        private void Awake()
        {
            DontDestroyOnLoad(this);
            Joustick();
        }

        private void RegisterInputService()
        {
            if (Application.isEditor)
            {
                InputServices = new StandaloneInputService();
                _isMobile = false;
                
            }
            else
            {
                InputServices = new MobileInputService();
                _isMobile = true;
            }
        }

        private void Joustick()
        {
            if (_isMobile == false)
                _joystick.gameObject.SetActive(false);
        }
    }
}