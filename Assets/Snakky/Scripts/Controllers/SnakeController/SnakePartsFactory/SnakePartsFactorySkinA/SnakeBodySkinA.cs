using UnityEngine;


namespace Snakyy
{
	
	public class SnakeBodySkinA : BaseSnakePart {

		public SnakeBodySkinA()
		{
			m_Obj = (GameObject)GameObject.Instantiate(Resources.Load<GameObject>("SnakeBodySkinA"), new Vector3(0, 0, 0), Quaternion.identity);
		}
	}
}
