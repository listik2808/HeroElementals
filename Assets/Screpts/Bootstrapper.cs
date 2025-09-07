using Screpts.Infrastructure;
using Screpts.Infrastructure.State;
using Screpts.Logic;
using UnityEngine;

namespace Screpts
{
    public class Bootstrapper : MonoBehaviour,ICoroutineRunner
    {
        public LoadingCurtain Curtain;

        private Game _game;

        private void Awake()
        {
            _game = new Game(this,Curtain);
            _game.StateMachine.Enter<BootstrapState>();

            DontDestroyOnLoad(this);
        }
    }
}