using UnityEngine;
using System.Collections;
using strange.extensions.command.impl;
using strange.extensions.context.impl;
using strange.extensions.context.api;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.dispatcher.eventdispatcher.impl;

namespace Snakyy{
	
	public class StartGameLevel1 : Command {

		[Inject (ContextKeys.CONTEXT_DISPATCHER)]
		public IEventDispatcher eventBus {get; set; }
		
		public override void Execute()
		{
			Debug.Log ("Level1 started");

			//PlayerPrefs.SetInt( "I" , 1);
//			string y = PlayerPrefs.GetString( "You" );
//			//PlayerPrefs.SetString( "You", "UUU" );
//			int x = PlayerPrefs.GetInt( "I" );
//			Debug.Log ("Test : " + x.ToString());
//			Debug.Log ("Test2 : " + y);

			injectionBinder.Bind<ISnakePartFactory>().To<SnakePartFactorySkinA>();

			injectionBinder.Bind<IDirectionController>().To<DirectionControllerArrows4>();
			injectionBinder.Bind<ISnake>().To<SnakeRectFieldSimple>().ToSingleton();

			injectionBinder.Bind<IEatObjectsController>().To<EatObjectsController>().ToSingleton();

			IField field = new RectField1(1024, 768);
			injectionBinder.Bind<IField>().ToValue(field).ToSingleton();


			// first probe
			ILevelDataManager levelDataMgr = LevelDataManager.GetInstance();
			injectionBinder.Bind<ILevelDataManager>().ToValue( levelDataMgr ).ToSingleton();
			// first probe

			IUserDataManager userDataMgr = UserDataManager.GetInstance();
			injectionBinder.Bind<IUserDataManager>().ToValue( userDataMgr ).ToSingleton();
			//injectionBinder.Bind<ILevelDataManager>().To<LevelDataManager>().ToSingleton().CrossContext();


			//injectionBinder.Bind<ILevelDataManager>().To<LevelDataManager>().ToSingleton().CrossContext();
					
			//GameObject.Find("GameLevel").AddComponent<MainSnakeController>();
			//MainSnakeController SnakeController = GameObject.Find("GameLevel").GetComponent<MainSnakeController>();
			//injectionBinder.injector.Inject( SnakeController );


			GameObject.Find("GameLevel").AddComponent<Game>();
			Game game = GameObject.Find("GameLevel").GetComponent<Game>();
			injectionBinder.injector.Inject( game );





			//Debug.Log("Level number " + LevelDataManager.GetInstance().currLevel.ToString());
			//LevelDataManager.GetInstance().currLevel = LevelDataManager.GetInstance().currLevel + 1;

			//GameObject.Find("GameLevel").AddComponent<EatObjectsController>();
			//EatObjectsController eatController = GameObject.Find("GameLevel").GetComponent<EatObjectsController>();
			//injectionBinder.injector.Inject( eatController );
			//injectionBinder.Bind<IMainSnakeController>().ToValue(SnakeController).ToSingleton();

		//	injectionBinder.injector.Inject( FieldController );
			
		}
	}
	
}

