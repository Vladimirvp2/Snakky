using UnityEngine;
using System.Collections;

namespace Snakyy 
{

    public class SnakeRectFieldNoBorder :  BaseRectSnake
	{
		public override void move(DirectionsEnum dir)
		{
			if (m_isPaused)
				return; 
			
			changeMoveDirection(dir);

			// move the snake from tail to head
			// move tail and body(except head)
			int snakeL = m_SnakeParts.Count;
			for (int i = snakeL - 1; i > 0; i--)
			{
				ISnakePart prevPart = (ISnakePart)m_SnakeParts[i];
				ISnakePart nextPart = (ISnakePart)m_SnakeParts[i-1];
				prevPart.tilePosition = nextPart.tilePosition;
				prevPart.position = nextPart.position;
				prevPart.rotation = nextPart.rotation;
			}

			
			// move head 
			ISnakePart head = (ISnakePart)m_SnakeParts[0];

			// if the snake head is close to border mirror it
			if (m_Field.tileBumpesBorder(head.tilePosition, currMoveDirection))
			{
				// find new (mirroerd) snake head position
				m_CurrHeadTilePosition = m_Field.getMirrorTile(head.tilePosition, currMoveDirection);
			}
			else
			{

			    switch(currMoveDirection){
			    case DirectionsEnum.UP: 
				    m_CurrHeadTilePosition = new Vector3(m_CurrHeadTilePosition.x, m_CurrHeadTilePosition.y + 1, m_CurrHeadTilePosition.z);
				    break;
			    case DirectionsEnum.DOWN: 
				    m_CurrHeadTilePosition = new Vector3(m_CurrHeadTilePosition.x, m_CurrHeadTilePosition.y - 1, m_CurrHeadTilePosition.z);
				    break;
			    case DirectionsEnum.RIGHT: 
				    m_CurrHeadTilePosition = new Vector3(m_CurrHeadTilePosition.x + 1, m_CurrHeadTilePosition.y, m_CurrHeadTilePosition.z);
				    break;
			    case DirectionsEnum.LEFT: 
				    m_CurrHeadTilePosition = new Vector3(m_CurrHeadTilePosition.x - 1, m_CurrHeadTilePosition.y, m_CurrHeadTilePosition.z); 
				    break;
			    default:
				    break;
			    }
			}
			
			head.position = m_Field.getAbsoluteCoordByTileCord( m_CurrHeadTilePosition );
			head.tilePosition = m_CurrHeadTilePosition;
			head.rotation = CommonMathFunctions.getQuaternionByDirection( currMoveDirection );


			
		}
    }
}
