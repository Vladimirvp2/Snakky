using UnityEngine;
using System.Collections;
using strange.extensions.command.impl;
using strange.extensions.context.impl;
using strange.extensions.context.api;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.dispatcher.eventdispatcher.impl;
using System.IO;
using SimpleJSON;

namespace Snakyy{
	
	public class StartAppCmd : Command {

		[Inject (ContextKeys.CONTEXT_DISPATCHER)]
		public IEventDispatcher eventBus {get; set; }

		public override void Execute()
		{







			// load level manager
			//ILevelDataManager levelDataMgr = LevelDataManager.GetInstance();
			//LevelDataManager data = new LevelDataManager();


			//injectionBinder.Bind<ILevelDataManager>().To<LevelDataManager>().ToSingleton().CrossContext();
			//injectionBinder.Bind<ILevelDataManager>().ToValue( data ).ToSingleton().CrossContext();

			// first probe
			//ILevelDataManager levelDataMgr = LevelDataManager.GetInstance();
			//levelDataMgr.currLevel = 1;

//			string a = "Game";
//			byte[] b = CommonStringFunctions.GetBytes( a );
//			int l = b.Length;
//			for (int i = 0; i < l; i++){
//				b[i] ^= 127;
//			}
//
//			string fin = CommonStringFunctions.GetString( b );
//
//			// = a ^ 128;
//			Debug.Log ( fin );
//
//			l = b.Length;
//			for (int i = 0; i < l; i++){
//				b[i] ^= 127;
//			}
//
//			string nFin = CommonStringFunctions.GetString( b );
//			Debug.Log ( nFin );
//			// first probe
//
//
//			byte[] bt = File.ReadAllBytes( "3.json");
//			string fin2 = CommonStringFunctions.GetString( bt );
//			Debug.Log ( "FF " + fin2 );
//
//			//File.WriteAllText("5.json", fin);
//			string sh = File.ReadAllText( "53.json" );
//			byte[] shb = CommonStringFunctions.GetBytes( sh );
//			int lsh = shb.Length;
//			for (int i = 0; i < l; i++){
//				shb[i] ^= 127;
//			}
//			
//			string finGG = CommonStringFunctions.GetString( shb );
//			Debug.Log("Final Test " + finGG);

			//Application.LoadLevel("Main");		
		}
	}
	
}