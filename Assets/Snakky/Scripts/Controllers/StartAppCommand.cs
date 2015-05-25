using UnityEngine;
using System.Collections;
using strange.extensions.command.impl;
using strange.extensions.context.impl;
using strange.extensions.context.api;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.dispatcher.eventdispatcher.impl;

namespace Snakyy{



    public class StartAppCommand : Command {

//        [Inject]
//	    public IGameService service{ get; set;} 

		
		[Inject (ContextKeys.CONTEXT_DISPATCHER)]
		public IEventDispatcher eventBus {get; set; }

	    public override void Execute()
	    {
//		    Debug.Log ("Start App");

	
//
//			Debug.Log ("Game created");
//
			injectionBinder.Bind<IObjectsHitProcessor>().To<ObjectsHitProcessor>().ToSingleton();
//
			eventBus.Dispatch(GameCommands.START_LEVEL1);

//			Debug.Log("Create field");
//			
//			IField field = new RectField1(1024, 768);
//			field.create();
//			hld.m_field = field;
//			
//			// place test 
//			GameObject m_Obj = (GameObject)GameObject.Instantiate(Resources.Load<GameObject>("SnakeHeadSkinB"), new Vector3(0, 0, 0), Quaternion.identity);
//			m_Obj.transform.position = field.getAbsoluteCoordByTileCord(new Vector3(0, 0, 0));
//			
//			GameObject m_Obj2 = (GameObject)GameObject.Instantiate(Resources.Load<GameObject>("SnakeHeadSkinB"), new Vector3(0, 0, 0), Quaternion.identity);
//			m_Obj2.transform.position = field.getAbsoluteCoordByTileCord(new Vector3(0, 10, 0));
//			
//			GameObject m_Obj3 = (GameObject)GameObject.Instantiate(Resources.Load<GameObject>("SnakeHeadSkinB"), new Vector3(0, 0, 0), Quaternion.identity);
//			m_Obj3.transform.position = field.getAbsoluteCoordByTileCord(new Vector3(10, 0, 0));
//			


		}
    }

}
