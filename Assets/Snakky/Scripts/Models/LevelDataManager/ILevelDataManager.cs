using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Snakyy{

    public interface ILevelDataManager {

	    int currLevel{get; set;}
		int fieldTileWidth{get;}
		int livesLeft{get;}
		EatObjectsEnum mainEatObject{get;}
		float snakeAcceleration{get;}
		List<EatObjetcStruct> eatObjectsData{get;}
		// if no data found, throws NullReferenceException
		EatObjetcStruct eatObjectData(EatObjectsEnum type);
		BonusesEnum getBonusTypeByObjectType(EatObjectsEnum type);

		void decreaseLive();
		void setFullLives();
    }
}
