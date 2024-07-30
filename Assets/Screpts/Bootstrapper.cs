using Screpts.Infrastructure;
using Screpts.Services.Input;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Screpts
{
    public class Bootstrapper : MonoBehaviour
    {
        private void Awake()
        {
            DontDestroyOnLoad(this);
            SceneManager.LoadScene("Main");
        }
    }
}