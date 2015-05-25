using UnityEngine;
using System.Collections;


namespace Snakyy{

	public class BaseSnakePart : ISnakePart {
		
		protected GameObject m_Obj;
		Vector3 m_TilePosition;

		public Vector3 position 
		{
			get { return m_Obj.transform.position; }
			set { m_Obj.transform.position = value; }
		}
		
		public Vector3 tilePosition {
			get{ return m_TilePosition;}
			set{m_TilePosition = value;}
		}
		
		
		public Quaternion rotation {
			get{ return m_Obj.transform.rotation;}
			set{m_Obj.transform.rotation = value;}
		}
		
		public Vector3 scale {
			get{ return m_Obj.transform.localScale;}
			set{ m_Obj.transform.localScale = value; }
		}

		public GameObject gameObject{
			get{ return m_Obj;}
		}
		
		public void destroy()
		{
			if (m_Obj){
				GameObject.Destroy( m_Obj );
				m_Obj = null;
			}
		}
    }
}
