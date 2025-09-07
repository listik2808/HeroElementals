using UnityEngine;

namespace Screpts.ServicesInput.Input
{
    public class MobileInputService : InputService
    {
        public override Vector2 Axis => SimplInputAxis();
    }
}
