using Screpts.Logic;
using UnityEngine;

namespace Screpts.Infrastructure
{
    public class LoadLevelState : IPayLoadedState<string>
    {
        private const string Path = "Player";
        private const string Hud = "Infrastructure/Hud";
        private const string InitialPoint = "InitialPoint";
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly LoadingCurtain _curtain;

        public LoadLevelState(GameStateMachine stateMachine,SceneLoader sceneLoader, LoadingCurtain curtain) 
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _curtain = curtain;
        }

        public void Enter(string sceneName)
        {
            _curtain.Show();
            _sceneLoader.Load(sceneName,OnLoaded);
        }

        public void Exit()
        {
            _curtain.Hide();
        }

        private void OnLoaded()
        {
            GameObject initialPoint = GameObject.FindWithTag(InitialPoint);

            GameObject hero = Instantiate(Path,initialPoint.transform.position);
            Instantiate(Hud);

            CameraFollow(hero);

            _stateMachine.Enter<GameLoopState>();
        }

        private static GameObject Instantiate(string path)
        {
            GameObject heroPrefab = Resources.Load<GameObject>(path);
            return Object.Instantiate(heroPrefab);
        }
        private static GameObject Instantiate(string path,Vector3 point)
        {
            GameObject heroPrefab = Resources.Load<GameObject>(path);
            return Object.Instantiate(heroPrefab,point,Quaternion.identity);
        }

        private void CameraFollow(GameObject hero)
        {
            Camera.main.GetComponent<CameraFollow>().Follow(hero);
        }
    }
}