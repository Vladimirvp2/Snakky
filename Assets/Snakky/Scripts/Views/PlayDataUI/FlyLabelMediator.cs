using UnityEngine;
using System.Collections;
using strange.extensions.mediation.impl;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.context.api;



namespace Snakyy
{
	
	public class FlyLabelMediator : Mediator 
	{

		[Inject]
		public FlyLabelView m_View{ get; set; }
		
		[Inject]
		public IUserDataManager m_UserData{ get; set; }
		
		[Inject (ContextKeys.CONTEXT_DISPATCHER)]
		public IEventDispatcher m_EventBus {get; set; }
		
		public FlyLabelMediator()
		{
			//renewUI();
		}
		
		public override void OnRegister ()
		{
			Debug.Log ("FlyLabelMediator FlyLabelMediator FlyLabelMediator");
			//m_View.setText(5);
		}
		
		public override void OnRemove ()
		{
	
		}

	}
}
