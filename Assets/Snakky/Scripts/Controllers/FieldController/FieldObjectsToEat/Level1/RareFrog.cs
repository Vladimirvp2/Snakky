using UnityEngine;

namespace Snakyy {
	
	public class RareFrog : BaseEatObject {
		
		public RareFrog(Vector3 spacePos){
			m_Obj = (GameObject)GameObject.Instantiate(Resources.Load<GameObject>("RareFrog"), spacePos, Quaternion.identity);
			m_Type = EatObjectsEnum.RARE_FROG;
		}	
	}
}
