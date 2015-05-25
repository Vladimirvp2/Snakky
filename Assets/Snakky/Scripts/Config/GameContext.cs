using UnityEngine;
using System.Collections;
using strange.extensions.context.api;
using strange.extensions.context.impl;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.dispatcher.eventdispatcher.impl;
using strange.extensions.context.impl;
using strange.extensions.context.api;
using strange.extensions.mediation.impl;


namespace Snakyy{

    public class GameContext : MVCSContext {

	    private View ob;
        public GameContext (MonoBehaviour view) : base(view)
	    {

	    }

	    protected override void mapBindings()
	    {
			// injections
			if (GameObject.Find("GameManager") != null)
			{
//			    GameController manager = GameObject.Find("GameManager").GetComponent<GameController>();
//			    injectionBinder.Bind<IGameController>().ToValue(manager);
			}

			injectionBinder.Bind<IFreePositionFinder>().To<FreePositionFinder>().ToSingleton();
			// commands
		    commandBinder.Bind(ContextEvent.START).To<StartAppCommand>();
			commandBinder.Bind(GameCommands.START_LEVEL1).To<StartGameLevel2>();

			mediationBinder.Bind<SnakeHeadView> ().To<SnakeHeadMediator>();
			mediationBinder.Bind<SnakeBodyView> ().To<SnakeBodyMediator>();
			mediationBinder.Bind<FrogView> ().To<FrogMediator>();	
			mediationBinder.Bind<RareFrogView> ().To<RareFrogMediator>();
			mediationBinder.Bind<PlayUIView> ().To<PlayUIMediator>();
			mediationBinder.Bind<FlyLabelView> ().To<FlyLabelMediator>();	
	    }
    }
}
