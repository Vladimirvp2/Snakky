using UnityEngine;
using System.Collections;
using strange.extensions.mediation.impl;

using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.dispatcher.eventdispatcher.impl;
using strange.extensions.context.api;



namespace Snakyy{
	
	public class FrogMediator : Mediator {
		
		[Inject]
		public FrogView view{ get; set; }
		
		[Inject (ContextKeys.CONTEXT_DISPATCHER)]
		public IEventDispatcher eventBus {get; set; }
		
		private EatableObjectEventStruct eventData;
		
		public FrogMediator(){
			eventData.type = EatObjectsEnum.FROG;
			eventData.gameObject = this.gameObject;
		}
		
		public override void OnRegister ()
		{
			view.collisionSignal.AddListener( onSnakeCollision );	
		}
		
		public override void OnRemove ()
		{
			view.collisionSignal.RemoveListener( onSnakeCollision );
		}
		
		private void onSnakeCollision()
		{
			eventBus.Dispatch(GameCommands.SNAKE_HIT_EATABLE_FIELD_OBJECT, eventData);
			//GameObject obj = (GameObject)GameObject.Instantiate(Resources.Load<GameObject>("FlyLabel"), this.gameObject.transform.position, Quaternion.identity);
		}
	}
}
