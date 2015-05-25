/* Author Vladimir Pishida 
 * Interface for all the direction controllers of 4 and 6
 * move directions: left, right(rect field), up, down(common),
 * down-right, down-left, up-right, up-left(hex field)
 */

using UnityEngine;

namespace Snakyy
{
    public interface IDirectionController {
	
		// gets the received move direction
		DirectionsEnum moveCmdReceived();
    }
}
