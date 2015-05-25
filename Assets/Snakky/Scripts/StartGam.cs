using UnityEngine;
using System.Collections;

namespace Snakyy{
static class hld
{
	public static IField m_field = null;
}
	

public class StartGam : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Debug.Log("Create field");
		IField field = new RectField1(1024, 768);
		field.create();
		hld.m_field = field;

		// place test 
		GameObject m_Obj = (GameObject)GameObject.Instantiate(Resources.Load<GameObject>("SnakeHeadSkinB"), new Vector3(0, 0, 0), Quaternion.identity);
		m_Obj.transform.position = field.getAbsoluteCoordByTileCord(new Vector3(0, 0, 0));

			GameObject m_Obj2 = (GameObject)GameObject.Instantiate(Resources.Load<GameObject>("SnakeHeadSkinB"), new Vector3(0, 0, 0), Quaternion.identity);
			m_Obj2.transform.position = field.getAbsoluteCoordByTileCord(new Vector3(0, 10, 0));

			GameObject m_Obj3 = (GameObject)GameObject.Instantiate(Resources.Load<GameObject>("SnakeHeadSkinB"), new Vector3(0, 0, 0), Quaternion.identity);
			m_Obj3.transform.position = field.getAbsoluteCoordByTileCord(new Vector3(10, 0, 0));
			
	}

}

}
