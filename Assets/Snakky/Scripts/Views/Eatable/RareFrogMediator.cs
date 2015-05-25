using UnityEngine;
using System.Collections;
using strange.extensions.mediation.impl;

using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.dispatcher.eventdispatcher.impl;
using strange.extensions.context.api;



namespace Snakyy{
	
	public class RareFrogMediator : Mediator {
		
		[Inject]
		public RareFrogView view{ get; set; }
		
		[Inject (ContextKeys.CONTEXT_DISPATCHER)]
		public IEventDispatcher eventBus {get; set; }

		private EatableObjectEventStruct eventData;

		public RareFrogMediator(){
			eventData.type = EatObjectsEnum.RARE_FROG;
			eventData.gameObject = this.gameObject;
		}

		public override void OnRegister ()
		{
			view.collisionSignal.AddListener( onSnakeCollision );
			view.liveExpiredSignal.AddListener( onLiveTimeExpired );	
		}

		public override void OnRemove ()
		{
			view.collisionSignal.RemoveListener( onSnakeCollision );
			view.liveExpiredSignal.RemoveListener( onLiveTimeExpired );	
		}

		private void onSnakeCollision()
		{
			eventBus.Dispatch(GameCommands.SNAKE_HIT_EATABLE_FIELD_OBJECT, eventData);
		}

		private void onLiveTimeExpired()
		{
			eventBus.Dispatch(GameCommands.LIVE_TIME_OUT_FOR_EATABLE_OBJECT, eventData);
		}
	}
}
