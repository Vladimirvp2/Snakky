using UnityEngine;


namespace Snakyy {

    public static class FieldObjectsFactory {

		public static IEatObject create(EatObjectsEnum type, Vector3 tilePos){
			IEatObject obj = null;
			Vector3 absPos = Game.getAbsoluteCoordByTileCord( tilePos );
			Vector3 scale = Game.getFieldScale();
			switch( type ){
			    case EatObjectsEnum.FROG: 
				    obj = new Frog( absPos );
				    break;
			    case EatObjectsEnum.RARE_FROG: 
				    obj = new RareFrog( absPos );
				    break;
			    case EatObjectsEnum.MOUSE: 
				    obj = new Mouse( absPos );
				    break;
			    case EatObjectsEnum.RARE_MOUSE: 
				    obj = new RareMouse( absPos );
				    break;
			    default:
				    return obj;
			}

			obj.tilePosition = tilePos;
			obj.scale = scale;
			obj.gameObject.transform.parent = GameObject.Find("GameLevel").transform;
			
			return obj;
		}
    }
}
