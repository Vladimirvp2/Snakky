/* Author Vladimir Pishida 
 * Findes move directions by 4 keyboard arrows.
 * For a rect field only(4 base directions)
 */


using UnityEngine;


namespace Snakyy
{
	public class DirectionControllerArrows4 : IDirectionController {

		public DirectionsEnum moveCmdReceived()
		{
			if (Input.GetAxis("Horizontal") < 0){
				return DirectionsEnum.LEFT;
			}
			else if (Input.GetAxis("Horizontal") > 0){
				return DirectionsEnum.RIGHT;
			}
			else if (Input.GetAxis("Vertical") > 0){
				return DirectionsEnum.UP;
			}
			else if (Input.GetAxis("Vertical") < 0){
				return DirectionsEnum.DOWN;
			}

			return DirectionsEnum.NONE;
		}
    }
}
