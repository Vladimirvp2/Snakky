/* Author Vladimir Pishida 
 * Findes move directions by 4 WASD keys.
 * For a rect field only(4 base directions)
 */


using UnityEngine;

namespace Snakyy
{
    public class DirectionControllerWASD4 : IDirectionController {

		public DirectionsEnum moveCmdReceived()
		{
			if (Input.GetKeyDown(KeyCode.A) ){
				return DirectionsEnum.LEFT;
			}
			else if (Input.GetKeyDown(KeyCode.D) ){
				return DirectionsEnum.RIGHT;
			}
			else if (Input.GetKeyDown(KeyCode.W) ){
				return DirectionsEnum.UP;
			}
			else if (Input.GetKeyDown(KeyCode.S) ){
				return DirectionsEnum.DOWN;
			}
			
			return DirectionsEnum.NONE;
		}
	}
}
