using Screpts.PortalZona;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Screpts.Infrastructure
{
    public class LoadScenePortal : MonoBehaviour
    {
        [SerializeField] private List<Portal> _portals = new List<Portal>();
    }
}
