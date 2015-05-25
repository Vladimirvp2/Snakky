using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Snakyy {

    //public class EatObjectsController : MonoBehaviour {
	public class EatObjectsController : IEatObjectsController  { 

		[Inject]
		public IField  m_Field{ get; set;} 

		[Inject]
		public IFreePositionFinder m_FreePosFinder{ get; set;}

		bool m_Pause = false;
		const int DEFAULT_PROBABLITY_N = 1; 
		float m_ProbabilityMult = 1.0f;
		float m_TimeCounter = 0.0f;
		const int TRIES_TO_GEN_RANDOM_POS = 2;

		// list contains data of possible eatable field objects
		List<EatObjetcStruct> m_ObjectsProb = new List<EatObjetcStruct>();
		EatObjectsEnum m_MainEatObject = EatObjectsEnum.NONE;

		public float probabilityMult{
			get{
				return m_ProbabilityMult;
			}
			set{
				m_ProbabilityMult = value;
			}
		}
		
		
		public EatObjectsController(){
			init();
		} 

		void init(){
			EatObjetcStruct st1;
			st1.type = EatObjectsEnum.RARE_FROG;
			st1.probabilityPerSecond = 0.2f;
			st1.maxNumberOnField = 2;
			st1.bonusAmountMin = 2;
			st1.bonusAmountMax = 3;
			st1.bonusType = BonusesEnum.NONE;
			m_ObjectsProb.Add(st1);

			m_MainEatObject = EatObjectsEnum.FROG;

		}

		
		public void start(){
			m_Pause = false;
		}

		public void update(){
			if (m_Pause)
				return;

			m_TimeCounter += Time.deltaTime;
			if (m_TimeCounter > 1f){
				// try to create new objects using their's probabilities 
				tryToCreateNewObjects();
				m_TimeCounter = 0f;
			}

			// if there is no main eatable object on the field create it
			if (m_Field.objectsCount(m_MainEatObject ) == 0){
				createObject( m_MainEatObject );
			}
		}


		public void pause(){
			m_Pause = true;
		}


		public void resume(){
			m_Pause = false;
		}


		void tryToCreateNewObjects(){
			foreach(EatObjetcStruct data in m_ObjectsProb){
				// check if max numner of certain objects not reached
				if (m_Field.objectsCount( data.type ) >= data.maxNumberOnField ){
					continue;
				}
				// generate random int based on probability data
				int randomN = Random.Range(0, (int)(1 / data.probabilityPerSecond ));
				Debug.Log ("Random " + randomN.ToString());
				if ( randomN == DEFAULT_PROBABLITY_N ){
					createObject( data.type );
				}

			}
		}

		void createObject(EatObjectsEnum type){
			Debug.Log ("Create new Object!!!");
			Vector3 pos = m_FreePosFinder.findFreeTilePosition();
			IEatObject obj = FieldObjectsFactory.create( type, pos );
			m_Field.addObject( obj, pos );
		}
    }
}
