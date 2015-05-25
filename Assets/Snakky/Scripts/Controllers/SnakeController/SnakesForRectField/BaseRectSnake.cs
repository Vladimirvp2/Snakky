using UnityEngine;
using System.Collections;


namespace Snakyy {

    public class BaseRectSnake : BaseSnake {

		[Inject]
		public ISnakePartFactory  m_SnakeFactory{ get; set;} 
		
		[Inject]
		public IField  m_Field{ get; set;} 

		public override void create(int length, Vector3 startTilePos, Vector3 scale)
		{	
			clearSnake();
			m_Scale = scale.x;
			
			// create head;
			ISnakePart head = m_SnakeFactory.getSnakePart(SnakeParts.HEAD, m_Field.getAbsoluteCoordByTileCord( startTilePos ), scale);
			head.tilePosition = startTilePos;
			m_SnakeParts.Add( head );
			//m_SnakeParts.Add( m_SnakeFactory.getSnakePart(SnakeParts.HEAD, m_Field.getAbsoluteCoordByTileCord( startTilePos ), scale) );
			m_CurrHeadTilePosition = startTilePos;
			
			// create middle parts
			for (int i = 0; i < length - 2; i++){
				Vector3 bodyTilePos = new Vector3(startTilePos.x - (i + 1), startTilePos.y, startTilePos.z);
				Vector3 bodySpacePos = m_Field.getAbsoluteCoordByTileCord( bodyTilePos );
				ISnakePart body = m_SnakeFactory.getSnakePart(SnakeParts.BODY, bodySpacePos, scale);
				body.tilePosition = bodyTilePos;
				m_SnakeParts.Add( body );
			}
			
			// create tail
			Vector3 tailTilePos = new Vector3(startTilePos.x - (length - 1), startTilePos.y, startTilePos.z);
			ISnakePart tail =  m_SnakeFactory.getSnakePart(SnakeParts.TAIL, m_Field.getAbsoluteCoordByTileCord( tailTilePos ), scale);
			tail.tilePosition = tailTilePos;
			m_SnakeParts.Add( tail );
			//m_SnakeParts.Add( m_SnakeFactory.getSnakePart(SnakeParts.TAIL, m_Field.getAbsoluteCoordByTileCord( tailTilePos ), scale) );
			
			// set default move direction
			currMoveDirection = DirectionsEnum.RIGHT;

			// set rotation to all the snake parts
			foreach(ISnakePart part in m_SnakeParts){
				part.rotation = CommonMathFunctions.getQuaternionByDirection( currMoveDirection );
			}
		}
		
		private void clearSnake(){
			foreach (ISnakePart part in m_SnakeParts )
			{
				part.destroy();
			}
			
			m_SnakeParts.Clear();
			
		}
		
		
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
			
			head.position = m_Field.getAbsoluteCoordByTileCord( m_CurrHeadTilePosition );
			head.tilePosition = m_CurrHeadTilePosition;
			head.rotation = CommonMathFunctions.getQuaternionByDirection( currMoveDirection );

		}
		
		
		// ckecks if to change the move direction
		protected virtual void changeMoveDirection(DirectionsEnum dir){
			// don't change direction if opposite
			if (dir == DirectionsEnum.NONE){
				return;
			}
			// don't change direction if opposite
			if ( (currMoveDirection == DirectionsEnum.UP && dir == DirectionsEnum.DOWN) ||
			    (currMoveDirection == DirectionsEnum.DOWN && dir == DirectionsEnum.UP) ){
				return;
			}
			if ( (currMoveDirection == DirectionsEnum.RIGHT && dir == DirectionsEnum.LEFT) ||
			    (currMoveDirection == DirectionsEnum.LEFT && dir == DirectionsEnum.RIGHT) ){
				return;
			}
			
			currMoveDirection = dir;
		}
		
		
		public override void addLength(int l) {
			int length = m_SnakeParts.Count;
			// define the move direction of the tail to add new parts correctly
			ISnakePart tail = (ISnakePart) m_SnakeParts[length-1];
			float scale = tail.scale.x;
			Vector3 posLast = ((ISnakePart) m_SnakeParts[length-1]).position;
			Vector3 posPrevLast = ((ISnakePart)m_SnakeParts[length-2]).position;
			
			DirectionsEnum dir = DirectionsEnum.NONE;
			if (Mathf.Abs(posLast.x - posPrevLast.x) < scale * 0.1f  && (posLast.y - posPrevLast.y) > scale * 0.5f )
			{
				dir = DirectionsEnum.DOWN;
			}
			else if (Mathf.Abs(posLast.x - posPrevLast.x) < scale * 0.1f  && (posPrevLast.y - posLast.y ) > scale * 0.5f ){
				dir = DirectionsEnum.UP;
			}
			else if ( Mathf.Abs(posLast.y - posPrevLast.y) < scale * 0.1f &&  (posLast.x - posPrevLast.x) > scale * 0.5f ){
				dir = DirectionsEnum.LEFT;
			}
			else if ( Mathf.Abs(posLast.y - posPrevLast.y) < scale * 0.1f &&  (posPrevLast.x - posLast.x) > scale * 0.5f ){
				dir = DirectionsEnum.RIGHT;                                                                                                                                                                                                                             ;
			}
			
			
			// add part to the tail
			Vector3 previousTailTilePos = tail.tilePosition;
			ISnakePart newPart = m_SnakeFactory.getSnakePart(SnakeParts.BODY, tail.position, tail.scale);
			newPart.tilePosition = tail.tilePosition;
			m_SnakeParts.Insert(length-1, newPart);
			// plase tail
			Vector3 newTilePos = previousTailTilePos;
			switch(dir){
			case DirectionsEnum.DOWN:
				newTilePos = previousTailTilePos + new Vector3(0, 1, 0);
				break;
			case DirectionsEnum.UP:
				newTilePos = previousTailTilePos + new Vector3(0, -1, 0);
				break;
			case DirectionsEnum.LEFT:
				newTilePos = previousTailTilePos + new Vector3(1, 0, 0);
				break;
			case DirectionsEnum.RIGHT:
				newTilePos = previousTailTilePos + new Vector3(-1, 0, 0);
				break;
			}
			
			tail.tilePosition = newTilePos;
			tail.position = m_Field.getAbsoluteCoordByTileCord( newTilePos );
			tail.rotation = CommonMathFunctions.getQuaternionByDirection( dir );
			
		}
		
		
		public override void cutLength(int l){
			// check if the length of the snake can be cut by l tiles
			if (m_SnakeParts.Count - l < MIN_TILE_LENGTH){
				l = m_SnakeParts.Count - MIN_TILE_LENGTH;
			}

			if (l <= 0)
				return;

			int snakeLength = m_SnakeParts.Count;
			// tail of the snake will be removed to this part
			ISnakePart lastPartToRemove = m_SnakeParts[snakeLength - 1 - l];
			Vector3 newTailAbsPos = lastPartToRemove.position;
			Vector3 newTailTilePos = lastPartToRemove.tilePosition;
			Quaternion newTailRot = lastPartToRemove.rotation;
			for (int i = snakeLength - 2; i > snakeLength - 2 - l; i--)
			{
				m_SnakeParts[i].destroy();
				m_SnakeParts.RemoveAt( i );
			}

			// set snake tail to new position
			ISnakePart tail = m_SnakeParts[m_SnakeParts.Count - 1];
			tail.position = newTailAbsPos;
			tail.tilePosition = newTailTilePos;
			tail.rotation = newTailRot;

		}
		
		public override void setStartPosition(Vector3 pos){}
		
		public override void playSwallowAnim(){}
		
		
	}

}
