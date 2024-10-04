using Screpts.Hero;
using Screpts.Logic;
using Screpts.Services.Input;

namespace Screpts.Infrastructure
{
    public class Game
    {
        public static IInputServices InputServices;
        public GameStateMachine StateMachine;

        public Game(ICoroutineRunner coroutineRunner,LoadingCurtain curtain)
        {
            StateMachine = new GameStateMachine(new SceneLoader(coroutineRunner),curtain);
        }

        private void ActivateHeroMove()
        {
            //_player.HeroMove.enabled = true;
        }
    }
}
