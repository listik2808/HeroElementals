using Screpts.Infrastructure.Services;
using Screpts.Infrastructure.State;
using System;
using UnityEngine;

namespace Screpts.PortalZona
{
    public class Portal : MonoBehaviour
    {
        [SerializeField] private string _nameScene;
        private IGameStateMachine _stateMachine;

        private void Awake()
        {
            _stateMachine = AllServices.Container.Single<IGameStateMachine>();
        }

        private void OnTriggerEnter(Collider other)
        {
            _stateMachine.Enter<LoadLevelState, string>(_nameScene);//можно сделать стейт который будет потом переходить в следующий режим битвы а не геймлупп!!!!
        }
    }
}