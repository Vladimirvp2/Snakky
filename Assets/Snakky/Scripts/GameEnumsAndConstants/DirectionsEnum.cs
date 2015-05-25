/* Author Vladimir Pishida 
 * Contains possible move diretions
 */

namespace Snakyy
{
    public enum DirectionsEnum {
		// common
	    UP = 0,
	    DOWN,
		// only for rect field
	    RIGHT,
	    LEFT,
		// only for hex field
		UP_RIGHT,
		UP_LEFT,
		DOWN_RIGHT,
		DOWN_LEFT,

		NONE
	}
}
