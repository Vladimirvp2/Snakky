using UnityEngine;
using System.Collections;

namespace Snakyy {
	
	public class Frog : BaseEatObject {
		
		public Frog(Vector3 spacePos){
			m_Obj = (GameObject)GameObject.Instantiate(Resources.Load<GameObject>("Frog"), spacePos, Quaternion.identity);
			m_Type = EatObjectsEnum.FROG;
		}	
	}
}
