using Screpts.Infrastructure.Services;
using UnityEngine;

namespace Screpts.ServicesInput.Input
{
    public interface IInputServices : IService
    {
        Vector2 Axis { get; }
    }
}
