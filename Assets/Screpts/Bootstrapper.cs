using Screpts.Services.Input;
using UnityEngine;

namespace Screpts
{
    public class Bootstrapper : MonoBehaviour
    {
        public static IInputServices InputServices;

        public Bootstrapper()
        {
            RegisterInputService();
        }

        private static void RegisterInputService()
        {
            if (Application.isEditor)
            {
                InputServices = new StandaloneInputService();
            }
            else
            {
                InputServices = new MobileInputService();
            }
        }
    }
}