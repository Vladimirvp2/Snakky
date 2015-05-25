using UnityEngine;
using System.Collections;
using strange.extensions.mediation.impl;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.context.api;



namespace Snakyy{
	
	public class PlayUIMediator : Mediator {
		
		[Inject]
		public PlayUIView m_View{ get; set; }

		[Inject]
		public IUserDataManager m_UserData{ get; set; }
		
		[Inject (ContextKeys.CONTEXT_DISPATCHER)]
		public IEventDispatcher m_EventBus {get; set; }

		public PlayUIMediator()
		{
			//renewUI();
		}

		public override void OnRegister ()
		{
			m_EventBus.AddListener( GameCommands.SCORE_ADD, renewScore );
			m_EventBus.AddListener( GameCommands.LIVE_ADD, renewLives );
			m_EventBus.AddListener( GameCommands.COIN_ADD, renewCoins );
			renewUI();
		}
		
		public override void OnRemove ()
		{
			m_EventBus.RemoveListener( GameCommands.SCORE_ADD, renewScore );
			m_EventBus.RemoveListener( GameCommands.LIVE_ADD, renewLives );
			m_EventBus.RemoveListener( GameCommands.COIN_ADD, renewCoins );
		}

		void renewUI()
		{
			renewScore();
			renewCoins();
			renewLives();
		}

		void renewScore(){
			int value = m_UserData.currScoreInCurrLevel;
			m_View.setScore( value );

			m_View.setMaxScore(m_UserData.maxScoreInLevel(m_UserData.level));
		}

		void renewLives(){
			int value = m_UserData.livesLeft;
			m_View.setLives( value );
		}

		void renewCoins(){
			int value = m_UserData.coins;
			m_View.setCoins( value );
		}
	}
}

