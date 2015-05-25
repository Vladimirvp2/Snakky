using UnityEngine;
using System.Collections;


namespace Snakyy {

    public interface IEatObject {

		GameObject gameObject{get;}
	    Vector3 position{get; set;}
	    Vector3 tilePosition{get; set;}
		Vector3 scale{get; set;}
		EatObjectsEnum type{get;}
    }
}
