using UnityEngine;
using System.Collections;


namespace Snakyy {
	
	public class RareMouse : BaseEatObject {
		
		public RareMouse(Vector3 spacePos){
			m_Obj = (GameObject)GameObject.Instantiate(Resources.Load<GameObject>("RareMouse"), spacePos, Quaternion.identity);
			m_Type = EatObjectsEnum.RARE_MOUSE;		
		}
	}
}
