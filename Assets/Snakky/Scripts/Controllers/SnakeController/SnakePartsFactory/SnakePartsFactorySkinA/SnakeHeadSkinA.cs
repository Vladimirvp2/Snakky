using UnityEngine;


namespace Snakyy
{
	public class SnakeHeadSkinA : BaseSnakePart {
		
		public SnakeHeadSkinA()
		{
			m_Obj = (GameObject)GameObject.Instantiate(Resources.Load<GameObject>("SnakeHeadSkinA"), new Vector3(0, 0, 0), Quaternion.identity);
		}
	}
}

