using UnityEngine;


namespace Snakyy
{
	public class SnakeTailSkinA : BaseSnakePart {
		
		public SnakeTailSkinA()
		{
			m_Obj = (GameObject)GameObject.Instantiate(Resources.Load<GameObject>("SnakeTailSkinA"), new Vector3(0, 0, 0), Quaternion.identity);
		}
	}
}

