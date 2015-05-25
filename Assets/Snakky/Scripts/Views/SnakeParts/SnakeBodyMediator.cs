using UnityEngine;
using System.Collections;
using strange.extensions.mediation.impl;

using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.dispatcher.eventdispatcher.impl;
using strange.extensions.context.api;



namespace Snakyy{
	
	public class SnakeBodyMediator : Mediator {
		
		[Inject]
		public SnakeBodyView view{ get; set; }
		
		[Inject (ContextKeys.CONTEXT_DISPATCHER)]
		public IEventDispatcher eventBus {get; set; }
		
		
		public override void OnRegister ()
		{
			Debug.Log ("++++++++++++++++++++++++++++++++++++++++++++");
			//eventBus.AddListener(Commands.Button1Pressed, buttonResponse);
		}
	}
	
}
