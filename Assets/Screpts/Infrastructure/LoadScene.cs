using Screpts.PortalZona;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Screpts.Infrastructure
{
    public class LoadScene : MonoBehaviour
    {
        [SerializeField] private List<Portal> _portals = new List<Portal>();

        private void OnDisable()
        {
            foreach (Portal portal in _portals)
            {
                portal.LoadScene -= SceneLoaded;
            }
        }

        private void OnEnable()
        {
            foreach (Portal portal in _portals)
            {
                portal.LoadScene += SceneLoaded;
            }
        }

        private void SceneLoaded(string sceneName)
        {
            StartCoroutine(Load(sceneName));
        }

        private IEnumerator Load(string nameScene)
        {
            AsyncOperation asyncOperationScene = SceneManager.LoadSceneAsync(nameScene);
            while(!asyncOperationScene.isDone)
                yield return null;
        }
    }
}
