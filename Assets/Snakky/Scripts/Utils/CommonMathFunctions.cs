using UnityEngine;
using System.Collections;


namespace Snakyy {

    public static class CommonMathFunctions  {

//		public static bool tileCoordsEqual(Vector3 v1, Vector3 v2){
//			if ( ((int)v1.x - (int)v2.x == 0) &&
//			    ((int)v1.y - (int)v2.y == 0)){
//				return true;
//			}
//
//			return false;
//		}

		public static bool tileCoordsEqual(Vector3 v1, Vector3 v2){
			if ( Mathf.Abs(v1.x - v2.x) < 0.01f &&
			    Mathf.Abs(v1.y - v2.y) < 0.01f){
				return true;
			}
			
			return false;
		}

		public static Quaternion getQuaternionByDirection(DirectionsEnum dir){
			switch(dir){
			    case DirectionsEnum.RIGHT:
				    return Quaternion.Euler(new Vector3(0, 0, -90));
			    case DirectionsEnum.LEFT:
			        return Quaternion.Euler(new Vector3(0, 0, 90));
			    case DirectionsEnum.UP:
				    return Quaternion.Euler(new Vector3(0, 0, 0));
			    case DirectionsEnum.DOWN:
				    return Quaternion.Euler(new Vector3(0, 0, -180));

			    default:
				    return Quaternion.Euler(new Vector3(0, 0, 0));
		    }
		}

		public static DirectionsEnum getOppositeDirection(DirectionsEnum dir)
		{
			switch(dir)
			{
			    case DirectionsEnum.UP:
				    return DirectionsEnum.DOWN;
			    case DirectionsEnum.DOWN:
				    return DirectionsEnum.UP;
			    case DirectionsEnum.LEFT:
				    return DirectionsEnum.RIGHT;
			    case DirectionsEnum.RIGHT:
				    return DirectionsEnum.LEFT;
			    default:
				    return DirectionsEnum.NONE;
			}
		}
    }
}