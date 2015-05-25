using UnityEngine;
using System.Collections;


namespace Snakyy {

    public interface ISnake  {

		DirectionsEnum currMoveDirection{get; set;}
		Vector3 currHeadTilePosition{get;}
		float speed{ get;}
		void create(int length, Vector3 startPos, Vector3 scale);
		void addLength(int l);
		void cutLength(int l);
		void increaseSpeed(float percent);
		void decreaseSpeed(float percent);

		void move(DirectionsEnum dir);
		void setStartPosition(Vector3 pos);

		void playSwallowAnim();
		// if the snake contains the given tile 
		bool tilePointIsFree(Vector3 v);

		void pause();
		void resume();
		void update();

    }
}
