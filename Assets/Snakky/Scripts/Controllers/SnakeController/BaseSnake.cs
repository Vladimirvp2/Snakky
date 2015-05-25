using UnityEngine;
using System.Collections;
using System.Collections.Generic;


namespace Snakyy
{
    public abstract class BaseSnake : ISnake {

		[Inject]
		public IDirectionController  moveController{ get; set;} 

		protected List<ISnakePart> m_SnakeParts = new List<ISnakePart>();
		protected const float PART_SIZE = 1.0f;
		protected float m_Scale = 1f;
		protected Vector3 m_CurrHeadTilePosition = new Vector3(0, 0, 0);
		protected DirectionsEnum m_CurrMoveDirection = DirectionsEnum.RIGHT;
		// current tile position of a snake's head on the field
		protected Vector2 m_HeadTilePosition;
		protected bool m_isPaused = false;

		private float m_Speed = 1.0f;
		const float MIN_SPEED = 0.5f;
		protected const int MIN_TILE_LENGTH = 3;


		float moveTime = 0.25f;
		float moveTimeCounter = 0.0f;
		// move direction received in the last move cycle(not applied yet)
		private DirectionsEnum userMoveDir;


		public float speed{
			get{ return m_Speed; }
		}
		
		public 	Vector3 currHeadTilePosition
		{
			get{return m_CurrHeadTilePosition; }
		}
		
		public DirectionsEnum currMoveDirection{
			get{ return m_CurrMoveDirection; }
			set{ m_CurrMoveDirection = value; }
		}

		public void increaseSpeed(float percent){
			m_Speed += percent;
		}

		public void decreaseSpeed(float percent){
			if (m_Speed - percent > MIN_SPEED){
				m_Speed -= percent;
			}
			else{
				m_Speed = MIN_SPEED;
			}
		}

		public abstract void create(int length, Vector3 startPos, Vector3 scale);
		public abstract void addLength(int l);
		public abstract void cutLength(int l);
		
		public abstract void move(DirectionsEnum dir);
		public abstract void setStartPosition(Vector3 pos);
		
		public abstract void playSwallowAnim();

		// if the snake contains the given tile 
		public virtual bool tilePointIsFree(Vector3 v){
			foreach(ISnakePart part in m_SnakeParts){
				if (CommonMathFunctions.tileCoordsEqual(v, part.tilePosition)){
					return false;
				}
			}
			
			return true;
		}

		public void pause(){
			m_isPaused = true;
		}

		public void resume(){
			m_isPaused = false;
		}

		// Update is called once per frame
		public void update () {
			
			// define new move direction form user
			getNewMoveDirectionFromUser();
			
			moveTimeCounter += (Time.deltaTime * speed);
			if (moveTimeCounter > moveTime)
			{
				move(userMoveDir);
				moveTimeCounter = 0f;
				userMoveDir = DirectionsEnum.NONE;
			}
		}
		
		
		void getNewMoveDirectionFromUser(){
			DirectionsEnum newDir = moveController.moveCmdReceived();
			// if not null direction received during move cycle dont override it with none direction
			if (userMoveDir != DirectionsEnum.NONE && newDir == DirectionsEnum.NONE)
			{
				return;
			}
			
			userMoveDir = newDir;
		}
    }
}
