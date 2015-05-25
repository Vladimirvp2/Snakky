using UnityEngine;
using System.Collections;


namespace Snakyy {

	public class Mouse : BaseEatObject {

		public Mouse(Vector3 spacePos){
			m_Obj = (GameObject)GameObject.Instantiate(Resources.Load<GameObject>("Mouse"), spacePos, Quaternion.identity);
			m_Type = EatObjectsEnum.MOUSE;
		}
	}
}
