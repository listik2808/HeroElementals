using Screpts.Infrastructure.AssetManagement;
using Screpts.Infrastructure.Factory;
using Screpts.Logic;
using UnityEngine;

namespace Screpts.Infrastructure.State
{
    public class LoadLevalBattle : IPayLoadedState<string>
    {
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly LoadingCurtain _curtain;
        private readonly IGameFactory _gameFactory;

        public LoadLevalBattle(GameStateMachine stateMachine, SceneLoader sceneLoader, LoadingCurtain curtain, IGameFactory gameFactory) 
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _curtain = curtain;
            _gameFactory = gameFactory;
        }

        public void Enter(string sceneName)
        {
            _curtain.Show();
            _sceneLoader.Load(sceneName, OnLoaded);
        }

        public void Exit()
        {
            _curtain.Hide();
        }

        private void OnLoaded()
        {
            GameObject hero = _gameFactory.CreateHero(GameObject.FindWithTag(AssetPath.InitialPoint));
            _gameFactory.CreateHud();

            CameraFollow(hero);
            // реализовать новый gameFactory который будет собирать врагов знать о точках спава спавнить их там и  давать команду бить героя при появление!!!
            _stateMachine.Enter<GameLoopState>();
        }

        private void CameraFollow(GameObject hero)
        {
            Camera.main.GetComponent<CameraFollow>().Follow(hero);
        }
    }
}