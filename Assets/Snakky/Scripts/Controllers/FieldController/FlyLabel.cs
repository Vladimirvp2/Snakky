using UnityEngine;
using System.Collections;


namespace Snakyy
{
    public static class FlyLabel {

	    public static void createFlyLabel(string text, Vector3 absPosition)
	    {
			GameObject m_Obj = (GameObject)GameObject.Instantiate(Resources.Load<GameObject>("FlyLabel"), absPosition, Quaternion.identity);
			FlyLabelView m_View = (FlyLabelView) m_Obj.GetComponent(typeof(FlyLabelView));
		    m_View.setText( text );
	    }
    }
}
