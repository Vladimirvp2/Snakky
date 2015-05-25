using UnityEngine;
using System.Collections;

namespace Snakyy
{
    public static class ScreenResolution  {
	
	    public static Resolution screenResolution()
	    {
		    Resolution res = new Resolution();
		    //res.width = 1024;
		    //res.height = 768;
			res.width = Screen.width;
			res.height = Screen.height;

			Debug.Log ("Resolution: " + res.width.ToString() + ", " + res.height.ToString());
		    return res;
	    }
    }
}
