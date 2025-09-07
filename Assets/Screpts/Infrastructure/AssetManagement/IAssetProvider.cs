using Screpts.Infrastructure.Services;
using UnityEngine;

namespace Screpts.Infrastructure.AssetManagement
{
    public interface IAssetProvider : IService
    {
        GameObject Instantiate(string path);
        GameObject Instantiate(string path, Vector3 point);
    }
}