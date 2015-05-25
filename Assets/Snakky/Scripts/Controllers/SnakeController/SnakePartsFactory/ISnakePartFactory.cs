using UnityEngine;

namespace Snakyy
{
    public interface ISnakePartFactory  {

		ISnakePart getSnakePart(SnakeParts part, Vector3 position, Vector3 scale);
    }

}
