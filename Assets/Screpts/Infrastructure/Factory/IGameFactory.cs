using Screpts.Infrastructure.Services;
using UnityEngine;

namespace Screpts.Infrastructure.Factory
{
    public interface IGameFactory : IService
    {
        GameObject CreateHero(GameObject initialPoint);
        void CreateHud();
    }
}