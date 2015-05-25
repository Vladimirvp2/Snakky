using System.Collections.Generic;
using UnityEngine;
using System.Collections;

namespace Snakyy
{
    public interface ISnakePart  {

	    Vector3 position {get; set;}
		Vector3 tilePosition {get; set;}
		Vector3 scale {get; set;}
		Quaternion rotation {get; set;}
		GameObject gameObject{get;}
		void destroy();
    }
}
