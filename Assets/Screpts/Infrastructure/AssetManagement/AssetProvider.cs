using UnityEngine;

namespace Screpts.Infrastructure.AssetManagement
{
    public class AssetProvider : IAssetProvider
    {
        public GameObject Instantiate(string path)
        {
            GameObject heroPrefab = Resources.Load<GameObject>(path);
            return Object.Instantiate(heroPrefab);
        }
        public GameObject Instantiate(string path, Vector3 point)
        {
            GameObject heroPrefab = Resources.Load<GameObject>(path);
            return Object.Instantiate(heroPrefab, point, Quaternion.identity);
        }
    }
}
