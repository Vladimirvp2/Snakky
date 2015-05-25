using UnityEngine;
using System.Collections;

namespace Snakyy
{

    public class SnakePartFactorySkinA : ISnakePartFactory {

		public ISnakePart getSnakePart(SnakeParts part, Vector3 pos, Vector3 scale)
		{
			ISnakePart snakePart = null;
			switch(part)
			{
			    case SnakeParts.HEAD: 
				    snakePart = new SnakeHeadSkinA();
				    break;
			    case SnakeParts.BODY: 
				    snakePart = new SnakeBodySkinA();
				    break;
			    case SnakeParts.TAIL: 
				    snakePart = new SnakeTailSkinA();
				    break;
			    default:
				    return null;
			}

			snakePart.position = pos;
			snakePart.scale = scale;
			snakePart.gameObject.transform.parent = GameObject.Find("GameLevel").transform;

			return snakePart;
		}
    }
}
