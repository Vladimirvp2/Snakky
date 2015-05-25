using UnityEngine;
using System.Collections;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.context.api;

namespace Snakyy {

        public class ObjectsHitProcessor : IObjectsHitProcessor {

	    [Inject]
	    public ILevelDataManager m_LevelDataMgr{ get; set;}

		[Inject]
		public ISnake  m_Snake{ get; set;} 

		[Inject]
		public IField m_Field{ get; set;} 

		[Inject]
		public IUserDataManager m_UserData{ get; set; }

		[Inject (ContextKeys.CONTEXT_DISPATCHER)]
		public IEventDispatcher m_EventBus {get; set; }
		
		public void processObjectHit(IEatObject obj) {
			// get random bonus amount
			EatObjetcStruct objData = m_LevelDataMgr.eatObjectData( obj.type );
			int bonusAnountMin = objData.bonusAmountMin;
			int bonusAmountMax = objData.bonusAmountMax;
			int bonusAmount = Random.Range(bonusAnountMin, bonusAmountMax);
			Debug.Log (" ==================== ObjectsHitProcessor " + bonusAmount.ToString() + " type " + objData.bonusType.ToString());

			processBonus(objData.bonusType, bonusAmount);
			// show fly bonus label
			FlyLabel.createFlyLabel(bonusAmount.ToString(), obj.position);

			m_Field.removeObject( obj.gameObject );

	    }

		void processBonus(BonusesEnum type, int amount){
			switch(type){
			    case BonusesEnum.SCORE:
				    m_UserData.addScoreToCurrLevel( amount );
				    m_EventBus.Dispatch(GameCommands.SCORE_ADD, amount);
				    break;
			    case BonusesEnum.COIN:
				    m_UserData.addCoins( amount );
				    m_EventBus.Dispatch(GameCommands.COIN_ADD, amount);
				    break;
			    case BonusesEnum.SCISSORS:
				    m_Snake.cutLength( amount );
				    break;		
			}
		}
    }
}

