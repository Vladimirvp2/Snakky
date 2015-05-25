using UnityEngine;
using strange.extensions.mediation.impl;
using System.Collections;
using UnityEngine.UI;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.dispatcher.eventdispatcher.impl;
using strange.extensions.context.api;


namespace Snakyy{
	
	
	public class SnakeBodyView  : View {
		
		[Inject (ContextKeys.CONTEXT_DISPATCHER)]
		public IEventDispatcher eventBus {get; set; }

		public void setScale(){}
		
		virtual protected void OnTriggerEnter(Collider other)
		{
			Debug.Log("Collision!!!");
		}
	}
	
}
