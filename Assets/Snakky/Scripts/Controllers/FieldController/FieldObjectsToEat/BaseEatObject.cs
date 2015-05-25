using UnityEngine;

namespace Snakyy {

    public class BaseEatObject :  IEatObject {

		protected GameObject m_Obj;
		protected EatObjectsEnum m_Type;
		Vector3 m_TilePosition;

		public 	GameObject gameObject{
			get{
				return m_Obj;
			}
		}

		public Vector3 position {
			get{
				return m_Obj.transform.position;
			}
			set{
				m_Obj.transform.position = value;
			}
		}

		public Vector3 scale
		{
			get{
				return m_Obj.transform.localScale;
			}
			set{
				m_Obj.transform.localScale = value;
			}
		}

		public Vector3 tilePosition{
			get{
				return m_TilePosition;
			} 
			set{
				m_TilePosition = value;
			}
		}

		public EatObjectsEnum type{
			get{
				return m_Type;
			}
		}
    }
}
