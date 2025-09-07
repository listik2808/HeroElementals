using Screpts.Hero;
using Screpts.Infrastructure.Services;
using Screpts.Infrastructure.State;
using Screpts.Logic;

namespace Screpts.Infrastructure
{
    public class Game
    {
        public GameStateMachine StateMachine;

        public Game(ICoroutineRunner coroutineRunner,LoadingCurtain curtain)
        {
            StateMachine = new GameStateMachine(new SceneLoader(coroutineRunner),curtain,AllServices.Container);
        }

        private void ActivateHeroMove()
        {
            //_player.HeroMove.enabled = true;
        }
    }
}
