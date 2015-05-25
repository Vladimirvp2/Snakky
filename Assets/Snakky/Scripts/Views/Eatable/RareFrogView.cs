using UnityEngine;
using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;


namespace Snakyy{
	
	
	public class RareFrogView  : View {

		internal Signal collisionSignal = new Signal ();
		internal Signal liveExpiredSignal = new Signal ();

		// get from data model
		float m_LiveTime = 10f;
		float m_TimeCounter = 0f;
		
		virtual protected void OnTriggerEnter(Collider other)
		{
			if (other.tag == PrefabTags.SNAKE_HEAD) {
				collisionSignal.Dispatch();
				Debug.Log("Collision with a rarefrog");
			}
		}

		void Update(){
			m_TimeCounter += Time.deltaTime;
			if ( m_TimeCounter > m_LiveTime){
				liveExpiredSignal.Dispatch();
				Debug.Log("Livetime of rarefrog expired");
			}
		}
	}
}