using UnityEngine;
using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;


namespace Snakyy{
	
	
	public class SnakeHeadView : View {
		
		internal Signal collisionBorderSignal = new Signal ();
		internal Signal snakeHitItselfSignal = new Signal ();
		
		virtual protected void OnTriggerEnter(Collider other)
		{
			if (other.tag == PrefabTags.FIELD_BORDER)
			{
				collisionBorderSignal.Dispatch();
				Debug.Log("Collision with border!");
			}

			Debug.Log ("TTTT " + other.tag.ToString());
			
			if (other.tag == PrefabTags.SNAKE_BODY || 
			    other.tag == PrefabTags.SNAKE_TAIL)
			{
				snakeHitItselfSignal.Dispatch();
				Debug.Log("Snake hit itself");
			}
		}
	}
}
