using UnityEngine;
using System.Collections;


namespace Snakyy{
    public class ChooseLevel : MonoBehaviour {

	    public void startLevel1(){
			//ILevelDataManager levelDataMgr = LevelDataManager.GetInstance();
			//levelDataMgr.currLevel = 1;
			Application.LoadLevel("Main");
	    }
    }

}
