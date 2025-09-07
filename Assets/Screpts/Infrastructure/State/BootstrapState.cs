using Screpts.Infrastructure.AssetManagement;
using Screpts.Infrastructure.Factory;
using Screpts.Infrastructure.Services;
using Screpts.Infrastructure.Services.PersistenProgress;
using Screpts.ServicesInput.Input;
using UnityEngine;

namespace Screpts.Infrastructure.State
{
    public class BootstrapState : IState
    {
        private const string Initial = "Initial";
        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly AllServices _service;

        public BootstrapState(GameStateMachine gameStateMachine,SceneLoader sceneLoader, AllServices service)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _service = service;

            RegisterServices();
        }

        public void Enter()
        {
            _sceneLoader.Load(Initial, EnterLoadLevel);
        }
        public void Exit()
        {
            
        }

        private void RegisterServices()
        {
            InputService();
            _service.RegisterSingle<IInputServices>(InputService());
            _service.RegisterSingle<IGameStateMachine>(_gameStateMachine);
            
            _service.RegisterSingle<IAssetProvider>(new AssetProvider());
            _service.RegisterSingle<IPersistenProgressService>(new PersistenProgressService());
            _service.RegisterSingle<IGameFactory>(new GameFactory(_service.Single<IAssetProvider>()));
        }
        private IInputServices InputService()
        {
            if (Application.isEditor)
                return new StandaloneInputService();
            else
                return new MobileInputService();
        }

        private void EnterLoadLevel()
        {
            _gameStateMachine.Enter<LoadLevelState,string>("Main");
        }
    }
}
