using UnityEngine;
using System.Collections;


namespace Snakyy
{
    public interface IField {

		int FieldTileWidth{get;}
		int FieldTileHeight{get;}
		float TileSizeInAbsCoord{get;}
		float tileScalef{get;}
		Vector3 tileScalev{get;}
		Vector2 StartSnakeTilePosition{get;}

		void create();
		void pause();
		void resume();
		void clear();

		Vector3 getAbsoluteCoordByTileCord(Vector3 v);

		bool tilePointIsFree(Vector3 v);

		void addObject(IEatObject obj, Vector3 tilePosition);
		void removeObject(GameObject obj);
		int objectsCount(EatObjectsEnum type);
		IEatObject getObject( GameObject obj );
		bool tileBumpesBorder(Vector3 tilePos, DirectionsEnum dir);
		Vector3 getMirrorTile(Vector3 tilePos, DirectionsEnum moveDir);

    }

}
