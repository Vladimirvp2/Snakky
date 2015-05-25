/* Author Vladimir Pishida 
 * Findes move directions by mouse touches.
 * For a rect field only(4 base directions)
 */


using UnityEngine;

namespace Snakyy
{
    public class DirectionControllerMouseSwipe4 : IDirectionController {

	    const int MIN_MOV_SQR_MAGNITUDE = 50;

		Vector2 firstPressPos;
		Vector2 secondPressPos;
		Vector2 currentSwipe;

		public DirectionsEnum moveCmdReceived()
		{
			if(Input.GetMouseButtonDown(0)){
				//save began touch 2d point
				firstPressPos = new Vector2(Input.mousePosition.x,Input.mousePosition.y);
			}
			if(Input.GetMouseButtonUp(0)){
				//save ended touch 2d point
				secondPressPos = new Vector2(Input.mousePosition.x,Input.mousePosition.y);
				
				//create vector from the two points
				currentSwipe = new Vector2(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);
				
				//normalize the 2d vector
				currentSwipe.Normalize();
				
				//swipe upwards
				if(currentSwipe.y > 0 &&  currentSwipe.x > -0.5f && currentSwipe.x < 0.5f){
					return DirectionsEnum.UP;
				}
				//swipe down
				if(currentSwipe.y < 0 &&  currentSwipe.x > -0.5f &&  currentSwipe.x < 0.5f){
					return DirectionsEnum.DOWN;
				}
				//swipe left
				if(currentSwipe.x < 0 &&  currentSwipe.y > -0.5f &&  currentSwipe.y < 0.5f){
					return DirectionsEnum.LEFT;
				}
				//swipe right
				if(currentSwipe.x > 0 &&  currentSwipe.y > -0.5f &&  currentSwipe.y < 0.5f){
					return DirectionsEnum.RIGHT;
				}
			}

			return DirectionsEnum.NONE;
		}
    }
}
