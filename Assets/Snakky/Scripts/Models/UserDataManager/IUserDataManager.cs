using UnityEngine;
using System.Collections;

namespace Snakyy{

    public interface IUserDataManager {

		// main method for user data changing 
		string userId{get; set;}
		string userName{set; get;}
		InputControllerEnum inputController{set; get;}
		SkinTypeEnum skinType{set; get;}
		LanguageEnum language{set; get;}
		CameraEnum cameraType{set; get;}

		// sound
		bool vibration{set; get;}
		bool sound{set; get;}

		// resources
		int coins{get; set;}
		void addCoins(int amount);
		//int maxScore{get; set;}
		//int currScore{get; set; }
		//int addCurrScore(int score);

		int livesLeft{get; set;}
		void resetLives();

		int level{get; set;}
		int maxScoreInLevel( int levelN );
		int currScoreInCurrLevel{get; set;}
		void addScoreToCurrLevel(int addScore);
		
	}
}
