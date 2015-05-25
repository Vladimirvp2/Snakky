using UnityEngine;
using System.Collections;
using strange.extensions.mediation.impl;

using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.dispatcher.eventdispatcher.impl;
using strange.extensions.context.api;



namespace Snakyy{
	
	public class SnakeHeadMediator : Mediator {
		
		[Inject]
		public SnakeHeadView view{ get; set; }
		
		[Inject (ContextKeys.CONTEXT_DISPATCHER)]
		public IEventDispatcher eventBus {get; set; }
		
		private EatableObjectEventStruct eventData;
		
		public SnakeHeadMediator(){
			eventData.type = EatObjectsEnum.FROG;
			eventData.gameObject = this.gameObject;
		}
		
		public override void OnRegister ()
		{
			view.collisionBorderSignal.AddListener( onBorderCollision );
			view.snakeHitItselfSignal.AddListener( onSnakeBodyCollision );
		}
		
		public override void OnRemove ()
		{
			view.collisionBorderSignal.RemoveListener( onBorderCollision );
			view.snakeHitItselfSignal.RemoveListener( onSnakeBodyCollision );
		}
		
		private void onBorderCollision()
		{
			eventBus.Dispatch(GameCommands.SNAKE_HIT_FIELD_BORDER, eventData);
		}

		private void onSnakeBodyCollision()
		{
			eventBus.Dispatch(GameCommands.SNAKE_HIT_ITSELF, eventData);
		}
	}
}
