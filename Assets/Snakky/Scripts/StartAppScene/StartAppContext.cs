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
	
	public class StartAppContext : MVCSContext {
		
		private View ob;
		public StartAppContext (MonoBehaviour view) : base(view)
		{
			
		}
		
		protected override void mapBindings()
		{
			// commands
			commandBinder.Bind(ContextEvent.START).To<StartAppCmd>();


		}
	}
}