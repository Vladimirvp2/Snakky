using UnityEngine;
using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;


namespace Snakyy{
	
	
	public class FrogView  : View {
		
		internal Signal collisionSignal = new Signal ();
			
		virtual protected void OnTriggerEnter(Collider other)
		{
			if (other.tag == PrefabTags.SNAKE_HEAD) {
				collisionSignal.Dispatch();
				Debug.Log("Collision with a frog");
			}
		}
	}
}
