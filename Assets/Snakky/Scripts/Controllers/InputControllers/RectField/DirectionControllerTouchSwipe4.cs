/* Author Vladimir Pishida 
 * Findes move directions by touches.
 * For a rect field only(4 base directions)
 */


using UnityEngine;

namespace Snakyy
{
	public class DirectionControllerTouchSwipe4 : IDirectionController {
		
		const int MIN_MOV_SQR_MAGNITUDE = 50;
		
		Vector2 firstPressPos;
		Vector2 secondPressPos;
		Vector2 currentSwipe;
		
		public DirectionsEnum moveCmdReceived()
		{
			if(Input.touches.Length > 0)
			{
				Touch t = Input.GetTouch(0);
				if(t.phase == TouchPhase.Began)
				{
					//save began touch 2d point
					firstPressPos = new Vector2(t.position.x,t.position.y);
				}
				if(t.phase == TouchPhase.Ended)
				{
					//save ended touch 2d point
					secondPressPos = new Vector2(t.position.x,t.position.y);
					
					//create vector from the two points
					currentSwipe = new Vector3(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);
					
					//normalize the 2d vector
					currentSwipe.Normalize();
					
					//swipe upwards
					if(currentSwipe.y > 0 &&  currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
					{
						return DirectionsEnum.UP;
					}
					//swipe down
					if(currentSwipe.y < 0 && currentSwipe.x > -0.5f &&  currentSwipe.x < 0.5f)
					{
						return DirectionsEnum.DOWN;
					}
					//swipe left
					if(currentSwipe.x < 0 &&  currentSwipe.y > -0.5f &&  currentSwipe.y < 0.5f)
					{
						return DirectionsEnum.LEFT;;
					}
					//swipe right
					if(currentSwipe.x > 0 && currentSwipe.y > -0.5f &&  currentSwipe.y < 0.5f)
					{
						return DirectionsEnum.RIGHT;;
					}
				}
			}

			return DirectionsEnum.NONE;
		}
	}
}
