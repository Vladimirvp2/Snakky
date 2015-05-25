using UnityEngine;
using System.Collections;
using strange.extensions.command.impl;
using strange.extensions.context.impl;
using strange.extensions.context.api;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.dispatcher.eventdispatcher.impl;

namespace Snakyy{
	
	public class StartGameLevel2 : Command {


		[Inject (ContextKeys.CONTEXT_DISPATCHER)]
		public IEventDispatcher eventBus {get; set; }
		
		public override void Execute()
		{
			Debug.Log ("Level1 started");

			
//			//PlayerPrefs.SetInt( "I" , 1);
//			string y = PlayerPrefs.GetString( "You" );
//			int x = PlayerPrefs.GetInt( "I" );
//			Debug.Log ("Test : " + x.ToString());
//			Debug.Log ("Test2 : " + y);

			ILocalizationManager locMng = LocalizationManager.GetInstance();
			ISoundManager sound = SoundManager.GetInstance();
			injectionBinder.Bind<ISoundManager>().ToValue( sound ).ToSingleton();
			
			injectionBinder.Bind<ISnakePartFactory>().To<SnakePartFactorySkinA>();
			
			injectionBinder.Bind<IDirectionController>().To<DirectionControllerTouchSwipe4>();
			//injectionBinder.Bind<IDirectionController>().To<DirectionControllerArrows4>();
			injectionBinder.Bind<ISnake>().To<SnakeRectFieldNoBorder>().ToSingleton();
			
			injectionBinder.Bind<IEatObjectsController>().To<EatObjectsController>().ToSingleton();

			//ScreenResolution
			IField field = new RectField1(Screen.width, Screen.height);
			injectionBinder.Bind<IField>().ToValue(field).ToSingleton();

			// first probe
			ILevelDataManager levelDataMgr = LevelDataManager.GetInstance();
			injectionBinder.Bind<ILevelDataManager>().ToValue( levelDataMgr ).ToSingleton();
			// first probe
			
			IUserDataManager userDataMgr = UserDataManager.GetInstance();
			userDataMgr.level = 1;
			injectionBinder.Bind<IUserDataManager>().ToValue( userDataMgr ).ToSingleton();
			//injectionBinder.Bind<ILevelDataManager>().To<LevelDataManager>().ToSingleton().CrossContext();
			
			GameObject.Find("GameLevel").AddComponent<Game>();
			Game game = GameObject.Find("GameLevel").GetComponent<Game>();
			injectionBinder.injector.Inject( game );
		}
	}
}